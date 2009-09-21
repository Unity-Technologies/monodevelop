//
// FindMemberVisitorTests.cs
//
// Author:
//   Mike Krüger <mkrueger@novell.com>
//
// Copyright (C)  2009  Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using Mono.TextEditor;
using MonoDevelop.Core;
using MonoDevelop.Projects;
using MonoDevelop.Projects.Dom;
using MonoDevelop.Projects.Dom.Parser;
using MonoDevelop.CSharpBinding;
using MonoDevelop.Projects.CodeGeneration;
using MonoDevelop.Projects.Text;
using ICSharpCode.NRefactory.Visitors;

namespace MonoDevelop.CSharpBinding.Tests
{
	[TestFixture]
	public class FindMemberVisitorTests : UnitTests.TestBase
	{
		#region TestHelper
		static NRefactoryParser parser = new NRefactoryParser ();
		
		void RunTest (string test)
		{
			StringBuilder     testText           = new StringBuilder ();
			List<DomLocation> expectedReferences = new List<DomLocation> ();
			DomLocation memberLocation = DomLocation.Empty;
			int line = 1, col = 1;
			foreach (char ch in test) {
				switch (ch) {
				case '$':
					memberLocation = new DomLocation (line, col);
					break;
				case '@':
					expectedReferences.Add (new DomLocation (line, col));
					break;
				default:
					col++;
					if (ch == '\n') {
						col = 1;
						line++;
					}
					testText.Append (ch);
					break;
				}
			}
			DotNetProject project = new DotNetProject ("C#");
			project.FileName = "/tmp/a.csproj";
			
			SimpleProjectDom dom = new SimpleProjectDom ();
			dom.Project = project;
			ProjectDomService.RegisterDom (dom, "Project:" + project.FileName);
			
			ParsedDocument parsedDocument = parser.Parse (null, "a.cs", testText.ToString ());
			dom.Add (parsedDocument.CompilationUnit);
			
			TestViewContent testViewContent = new TestViewContent ();
			testViewContent.Name = "a.cs";
			testViewContent.Text = testText.ToString ();
		//	RefactorerContext ctx = new RefactorerContext (dom, new DumbTextFileProvider(testViewContent), null);
			NRefactoryResolver resolver = new NRefactoryResolver (dom, 
			                                                      parsedDocument.CompilationUnit, 
			                                                      MonoDevelop.Ide.Gui.TextEditor.GetTextEditor (testViewContent), 
			                                                      "a.cs");
			SearchMemberVisitor smv = new SearchMemberVisitor (memberLocation.Line);
			smv.Visit (parsedDocument.CompilationUnit, null);
			if (smv.FoundMember == null) {
				ResolveResult resolveResult = resolver.ResolveIdentifier ("a", memberLocation);
				if (resolveResult is LocalVariableResolveResult)
					smv.FoundMember = ((LocalVariableResolveResult)resolveResult).LocalVariable;
			}
			Assert.IsNotNull (smv.FoundMember, "Member to search not found.");
			FindMemberAstVisitor astVisitor = new FindMemberAstVisitor (resolver, testViewContent, smv.FoundMember);
			astVisitor.RunVisitor ();
			
			int i = 0, j = 0;
			StringBuilder errorText = new StringBuilder ();
			Document doc = new Document ();
			doc.Text = testViewContent.Text;
			while (i < expectedReferences.Count && j < astVisitor.FoundReferences.Count) {
				
				if (expectedReferences[i].Line != astVisitor.FoundReferences[j].Line || expectedReferences[i].Column != astVisitor.FoundReferences[j].Column) {
					if (expectedReferences[i].Line < astVisitor.FoundReferences[j].Line) {
						errorText.Append ("Reference at  line " + expectedReferences[i].Line + " not found.");
						errorText.AppendLine ();
						errorText.Append (doc.GetTextAt (doc.GetLine (expectedReferences[i].Line - 1)).Replace ('\t', ' '));
						errorText.AppendLine ();
						errorText.Append (new string (' ', expectedReferences[i].Column));errorText.Append ('^');
						errorText.AppendLine ();
						i++;
						continue;
					}
					if (expectedReferences[i].Line > astVisitor.FoundReferences[j].Line) {
						errorText.Append ("Found unexpected Reference at line " + astVisitor.FoundReferences[j].Line);
						errorText.AppendLine ();
						errorText.Append (doc.GetTextAt (doc.GetLine (astVisitor.FoundReferences[j].Line - 1)).Replace ('\t', ' '));
						errorText.AppendLine ();
						errorText.Append (new string (' ', astVisitor.FoundReferences[j].Column));errorText.Append ('^');
						errorText.AppendLine ();
						j++;
						continue;
					}
					
					errorText.Append ("Column mismatch at line " + astVisitor.FoundReferences[j].Line + " was: " + astVisitor.FoundReferences[j].Column + " should be:" + expectedReferences[i].Column);
					errorText.AppendLine ();
					errorText.Append (doc.GetTextAt (doc.GetLine (astVisitor.FoundReferences[j].Line - 1)).Replace ('\t', ' '));
					errorText.Append (new string (' ', expectedReferences[i].Column));errorText.Append ('^');
					errorText.AppendLine ();
					errorText.Append (new string (' ', astVisitor.FoundReferences[j].Column));errorText.Append ('^');
					errorText.AppendLine ();
				}
				i++;j++;
			}
			while (i < expectedReferences.Count) {
				errorText.Append ("Reference at  line " + expectedReferences[i].Line + " not found.");
				errorText.AppendLine ();
				errorText.Append (doc.GetTextAt (doc.GetLine (expectedReferences[i].Line - 1)).Replace ('\t', ' '));
				errorText.AppendLine ();
				errorText.Append (new string (' ', expectedReferences[j].Column));errorText.Append ('^');
				errorText.AppendLine ();
				i++;
			}
			while (j < astVisitor.FoundReferences.Count) {
				errorText.Append ("Found unexpected Reference at line " + astVisitor.FoundReferences[j].Line);
				errorText.AppendLine ();
				errorText.Append (doc.GetTextAt (doc.GetLine (astVisitor.FoundReferences[j].Line - 1)).Replace ('\t', ' '));
				errorText.AppendLine ();
				errorText.Append (new string (' ', astVisitor.FoundReferences[i].Column));errorText.Append ('^');
				errorText.AppendLine ();
				j++;
			}
			if (errorText.Length > 0)
				Assert.Fail ("Member to find:" + smv.FoundMember + Environment.NewLine + errorText.ToString () + Environment.NewLine + "found : " + astVisitor.FoundReferences.Count + " expected:" + expectedReferences.Count);
		}
		
		class DumbTextFileProvider : ITextFileProvider
		{
			IEditableTextFile file;
			public DumbTextFileProvider (IEditableTextFile file)
			{
				this.file = file;
			}
			public IEditableTextFile GetEditableTextFile (FilePath filePath)
			{
				return file;
			}
		}
		
		class SearchMemberVisitor : AbstractDomVistitor<object, object>
		{
			public INode FoundMember {
				get;
				set;
			}
			int lineNumber;
			public SearchMemberVisitor (int lineNumber)
			{
				this.lineNumber = lineNumber;
			}
			
			void Check (IMember member)
			{
				if (member.Location.Line == lineNumber) {
					FoundMember = member;
				}
			}
			
			public override object Visit (IType type, object data)
			{
				Check (type);
				foreach (IMember member in type.Members) {
					member.AcceptVisitor (this, data);
				}
				return base.Visit (type, data);
			}
		
			public override object Visit (IField field, object data)
			{
				Check (field);
				return base.Visit (field, data);
			}
			
			public override object Visit (IMethod method, object data)
			{
				Check (method);
				return base.Visit (method, data);
			}
			
			public override object Visit (MonoDevelop.Projects.Dom.IParameter parameter, object data)
			{
				if (parameter.Location.Line == lineNumber)
					FoundMember = parameter;
				return base.Visit (parameter, data);
			}

			public override object Visit (IProperty property, object data)
			{
				Check (property);
				return base.Visit (property, data);
			}
			
			public override object Visit (IEvent evt, object data)
			{
				Check (evt);
				return base.Visit (evt, data);
			}
			
			public override object Visit (LocalVariable var, object data)
			{
				if (var.Region.Start.Line == lineNumber)
					FoundMember = var;
				return base.Visit (var, data);
			}
		}
		#endregion
		
		[Test()]
		public void FindClassReferences ()
		{
			RunTest (
@"class $@Test {
	@Test (@Test t)
	{
	}
	~@Test ()
	{}

	void TestMe(@Test p)
	{
		@Test i;
	}
}

delegate @Test TestDelegate (@Test test);

class OuterTest : @Test
{
	@Test testField;
	@Test TestProperty { get { } }
	
	event @Test TestEvent;
	public @Test this[int i] { get { } }
	public int this[@Test t] { get { } }
	
	public OuterTest (object t) : base ((@Test)t)
	{
	}

	@Test Outer (object o)
	{
		return ((@Test)o);
	}
}
namespace SomethingDifferent 
{
	class Test
	{
	}
}
");
		}
		
		[Test()]
		public void FindFieldReferences ()
		{
			RunTest (
@"class TestClass {
	protected int $@testField;

	TestClass ()
	{
		@testField = 5;
	}
	
	void TestMe(int f)
	{
		this.@testField = f;
	}
}


class OuterTest : TestClass
{
	int TestProperty { get { return base.@testField; } }
}

namespace SomethingDifferent
{
	class Test
	{
		int testField;
	}
}
");
		}
		
		[Test()]
		public void FindEventReferences ()
		{
			RunTest (
@"class TestClass {
	delegate void TestEventDelegate ();

	public event TestEventDelegate $@MyEvent;

	TestClass ()
	{
		@MyEvent += TestMe;
	}
	
	void TestMe()
	{
	}
}


class OuterTest : TestClass
{
	void Test ()
	{
		@MyEvent -= TestMe;
	}
}

namespace SomethingDifferent
{
	class Test
	{
		public event TestClass.TestEventDelegate MyEvent;
	}
}
");
		}
		
		[Test()]
		public void FindMethodReferences ()
		{
			RunTest (
@"class TestClass {
	public void $@TestMethod (
int a, int b)
	{
	}
	public void TestMethod (int a)
	{
		@TestMethod (a, 6);
	}
	public void TestMethod ()
	{
		TestMethod (4);
	}
}


class OuterTest : TestClass
{
	void A ()
	{
		@TestMethod (5, 4);
		TestMethod (5);
	}
}

namespace SomethingOuter
{
	class Test
	{
		void Bla (TestClass t)
		{
			t.@TestMethod (5, 4);
		}
	}
}
");
		}
		
		[Test()]
		public void FindPropertyReferences ()
		{
			RunTest (
@"class TestClass {
	public int $@MyProperty { get {} set {}}
	
	public void TestMethod (int a)
	{
		@MyProperty = a;
	}
	public void TestMethod ()
	{
		WriteLine (this.@MyProperty);
	}
}


class OuterTest : TestClass
{
	void A ()
	{
		@MyProperty = 5;
		WriteLine (base.@MyProperty);
		WriteLine (this.@MyProperty);
	}
}

namespace SomethingOuter
{
	class Test
	{
		void Bla (TestClass t)
		{
			t.@MyProperty = 5;
		}
	}
}
");
		}

		[Test()]
		public void FindParameterReferences ()
		{
			RunTest (
@"class TestClass {
	public void TestMethod (
int $@a, 
int b)
	{
		WriteLine (@a);
		@a--;
		b = @a;
		@a = b;
	}
}
");
		}

		[Test()]
		public void FindLocalVariableReferences ()
		{
			RunTest (
@"class TestClass {
	public void TestMethod ()
	{
		int $@a;
		int b = 5;
		WriteLine (@a);
		@a--;
		b = @a;
		@a = b;
	}

	public void TestMethod2 ()
	{
		int a;
		WriteLine (a);
		a--;
		int b = a;
	}
}
");
		}
		
		/// <summary>
		/// Bug 480492 - Find field references returns incorrect references
		/// </summary>
		[Test()]
		public void TestBug480492 ()
		{
			RunTest (
@"class BaseClass
{
}

class A : BaseClass
{
	BaseClass $@myField;
}

class B : BaseClass
{
	BaseClass myField;
	void TestMe ()
	{
		myField = null; // this should not be found.
		this.myField = null; // this should not be found.
	}
}");
		}
			
		/// <summary>
		/// Bug 493202 - List References on private constructor yields nothing
		/// </summary>
		[Test()]
		public void TestBug493202 ()
		{
			RunTest (
@"public class Foo {
   $@Foo () //right click on Foo and list constructor references
   {}

   public Foo Instance()
   {
     return new @Foo ();
   }
}
");
		}
		
		
				
		/// <summary>
		/// Bug 531525 - Refactoring + Renaming fails for delegate
		/// </summary>
		[Test()]
		public void TestBug531525 ()
		{
			RunTest (
@"public class Foo {
	void $@IdeAppWorkspaceSolutionLoaded (
object sender, 
SolutionEventArgs e)
	{}

	public void Main()
	{
		IdeApp.Workspace.SolutionLoaded += @IdeAppWorkspaceSolutionLoaded;
	}
}
");
		}
		
		
		/*
		[Test()]
		public void FindInterfaceMethodReferences ()
		{
			RunTest (
@"
public interface ITest {
    void $@doSomething(double par);
}

public abstract class AbstractTest: ITest {
    public abstract void @doSomething(double par); // Not renamed!!
}

public class ConcreteTest: AbstractTest {
    public override void @doSomething(double par)
    {
		base.@doSomething(par);
    }
}
");
		}
		
		[Test()]
		public void FindOverridenMethodReferences ()
		{
			RunTest (
@"
public class BaseTest
{
	public virtual void $@MyMethod()
	{
		@MyMethod ();
	}
}

public class Test : BaseTest
{
	public override void @MyMethod()
	{
		@MyMethod ();
	}
}
");
		}*/

	}
}
