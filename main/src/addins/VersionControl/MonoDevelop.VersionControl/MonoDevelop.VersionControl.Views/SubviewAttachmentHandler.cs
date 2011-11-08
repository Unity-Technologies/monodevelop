// 
// SubviewAttachmentHandler.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2010 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Linq;
using MonoDevelop.Components.Commands;
using Mono.Addins;
using MonoDevelop.VersionControl;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.VersionControl.Views
{
	class SubviewAttachmentHandler : CommandHandler
	{
		protected override void Run ()
		{
			Ide.IdeApp.Workbench.DocumentOpened += HandleDocumentOpened;
			Core.FileService.FileChanged += HandleCoreFileServiceFileChanged;
		}
		
		void AttachViewContents (MonoDevelop.Ide.Gui.Document document)
		{
			if (document == null || document.Project == null)
				return;
			var repo = VersionControlService.GetRepository (document.Project);
			if (repo == null)
				return;
			if (!document.IsFile || !repo.GetVersionInfo (document.FileName).IsVersioned)
				return;
			if (document.Editor == null)
				return;
			
			var item = new VersionControlItem (repo, document.Project, document.FileName, false, null);
			TryAttachView <IDiffView> (document, item, DiffCommand.DiffViewHandlers);
			TryAttachView <IBlameView> (document, item, BlameCommand.BlameViewHandlers);
			TryAttachView <ILogView> (document, item, LogCommand.LogViewHandlers);
			TryAttachView <IMergeView> (document, item, MergeCommand.MergeViewHandlers);
		}

		void HandleCoreFileServiceFileChanged (object sender, Core.FileEventArgs e)
		{
			foreach (Core.FileEventInfo info in e) {
				AttachViewContents (Ide.IdeApp.Workbench.GetDocument (info.FileName.FullPath));
			}
		}

		void HandleDocumentOpened (object sender, Ide.Gui.DocumentEventArgs e)
		{
			AttachViewContents (e.Document);
		}
		
		void TryAttachView <T> (Document document, VersionControlItem item, string type)
			where T : IAttachableViewContent
		{
			// Don't reattach existing views
			if (0 <= document.Window.FindView<T> ())
				return;
				
			var handler = AddinManager.GetExtensionObjects<IVersionControlViewHandler<T>> (type).FirstOrDefault (h => h.CanHandle (item));
			if (handler != null) {
				document.Window.AttachViewContent (handler.CreateView (item, document.PrimaryView));
			}
		}
	}
}

