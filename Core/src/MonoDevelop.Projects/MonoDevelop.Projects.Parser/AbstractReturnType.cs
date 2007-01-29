// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>
using System;
using System.Text;
using MonoDevelop.Projects.Utility;

namespace MonoDevelop.Projects.Parser
{
	[Serializable]
	public class DefaultReturnType : IReturnType
	{
		protected int    pointerNestingLevel;
		protected int[]  arrayDimensions;
		protected object declaredin = null;
		protected ReturnTypeList genericArguments;
		protected bool   byRef;
		string fname;
		
		public DefaultReturnType ()
		{
		}
		
		public DefaultReturnType (string fullyQualifiedName)
		{
			FullyQualifiedName = fullyQualifiedName;
		}
		
		public DefaultReturnType (string fullyQualifiedName, int[] arrayDimensions, int pointerNestingLevel, ReturnTypeList genericArguments)
		{
			this.FullyQualifiedName  = fullyQualifiedName;
			this.arrayDimensions     = arrayDimensions;
			this.pointerNestingLevel = pointerNestingLevel;
			this.genericArguments    = genericArguments;
		}
		
		public virtual string FullyQualifiedName {
			get {
				return fname;
			}
			set {
				if (value == null)
					fname = value;
				else {
					fname = AbstractNamedEntity.GetSharedString (value);
				}
			}
		}

		public virtual string Name {
			get {
				if (FullyQualifiedName == null) {
					return null;
				}
				string[] name = FullyQualifiedName.Split(new char[] {'.'});
				return name[name.Length - 1];
			}
		}

		public virtual string Namespace {
			get {
				if (FullyQualifiedName == null) {
					return null;
				}
				int index = FullyQualifiedName.LastIndexOf('.');
				return index < 0 ? String.Empty : FullyQualifiedName.Substring(0, index);
			}
		}


/*
		string name;
		string ns;
		public virtual string FullyQualifiedName {
			get {
				if (ns == null || ns.Length == 0)
					return name;
				else if (name != null)
					return string.Concat (ns, ".", name);
				else
					return null;
			}
			set {
				if (value == null) {
					ns = null;
					name = null;
					return;
				}
				int i = value.LastIndexOf ('.');
				if (i == -1) {
					ns = null;
					name = value;
				} else {
					ns = value.Substring (0, i);
					name = value.Substring (i+1);
				}
			}
		}

		public virtual string Name {
			get { return name; }
			set { name = value; }
		}

		public virtual string Namespace {
			get { return ns ?? string.Empty; }
			set { ns = value; }
		}
*/

		public virtual int PointerNestingLevel {
			get { return pointerNestingLevel; }
			set { pointerNestingLevel = value; }
		}

		public int ArrayCount {
			get {
				return ArrayDimensions.Length;
			}
		}

		public virtual int[] ArrayDimensions {
			get {
				if (arrayDimensions == null) return new int[0];
				return arrayDimensions;
			}
			set {
				arrayDimensions = value;
			}
		}
		 		
		/// <summary>
		/// Indicates whether the return type is passed by reference.
		/// </summary>
		public virtual bool ByRef {
			get { return byRef; }
			set { byRef = value; }
		}
		 		
		/// <summary>
		/// Contains values (types) of actual parameters (arguments) to a
		/// generic type.
		/// </summary>
		public virtual ReturnTypeList GenericArguments {
			get {
				return genericArguments;
			}
			set {
				genericArguments = value;
			}
		}

		public virtual int CompareTo (object ob) 
		{
			int cmp;
			IReturnType value = (IReturnType) ob;
			
			if (FullyQualifiedName != null) {
				if (value.FullyQualifiedName == null)
					return -1;
				cmp = FullyQualifiedName.CompareTo(value.FullyQualifiedName);
				if (cmp != 0) {
					return cmp;
				}
			} else if (value.FullyQualifiedName != null)
				return 1;
			
			cmp = (PointerNestingLevel - value.PointerNestingLevel);
			if (cmp != 0) {
				return cmp;
			}
			
			cmp = DiffUtility.Compare(ArrayDimensions, value.ArrayDimensions);
			if (cmp != 0)
				return cmp;
			
			if (GenericArguments == value.GenericArguments)
				return 0;
			else
				return DiffUtility.Compare(GenericArguments, value.GenericArguments);
		}
		
		int IComparable.CompareTo(object value)
		{
			return CompareTo((IReturnType)value);
		}
		
		public override bool Equals (object ob)
		{
			IReturnType other = ob as IReturnType;
			if (other == null) return false;
			return CompareTo (other) == 0;
		}
		
		public override int GetHashCode ()
		{
			int c = PointerNestingLevel;
			if (ArrayDimensions != null)
				for (int n=0; n<ArrayDimensions.Length; n++)
					c += arrayDimensions [n];
			if (FullyQualifiedName != null)
				c += FullyQualifiedName.GetHashCode ();
			return c;
		}
		
		public virtual object DeclaredIn {
			get {
				return declaredin;
			}
		}
		
		public override string ToString ()
		{
			return ToString (this);
		}
		
		public static string ToString (IReturnType type)
		{
			StringBuilder sb = new StringBuilder (DefaultClass.GetInstantiatedTypeName (type.FullyQualifiedName, type.GenericArguments));
			
			if (type.PointerNestingLevel > 0)
				sb.Append (new string ('*', type.PointerNestingLevel));

			if (type.ArrayDimensions != null && type.ArrayDimensions.Length > 0) {
				foreach (int dim in type.ArrayDimensions) {
					sb.Append ('[').Append (new string (',', dim - 1)).Append (']');
				}
			}
			
			return sb.ToString ();
		}
	}
	
}
