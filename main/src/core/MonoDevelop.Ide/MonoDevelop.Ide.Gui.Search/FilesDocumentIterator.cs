//  FilesDocumentIterator.cs
//
//  This file was derived from a file from #Develop. 
//
//  Copyright (C) 2001-2007 Mike Krüger <mkrueger@novell.com>
//  Copyright (C) 2008 Novell, Inc. (http://www.novell.com)
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

using MonoDevelop.Projects;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.Ide.Gui.Search
{
	abstract class FilesDocumentIterator : IDocumentIterator
	{
		protected List<string> files = new List<string> ();
		
		protected int curIndex = -1;
		
		public FilesDocumentIterator()
		{
			Reset();
		}
		
		public abstract string GetSearchDescription (string pattern);
		public abstract string GetReplaceDescription (string pattern);
		
		public string CurrentFileName {
			get {
				if (curIndex < 0 || curIndex >= files.Count) {
					return null;
				}
				
				return files[curIndex];
			}
		}
		
		bool IsValid ()
		{
			if (curIndex < 0 || curIndex >= files.Count)
				return true;
			string fileName = files[curIndex];
			if (!File.Exists (fileName))
				return false;
			string mimeType = IdeApp.Services.PlatformService.GetMimeTypeForUri ("file://" + fileName);
			return !String.IsNullOrEmpty (mimeType) && IdeApp.Services.PlatformService.GetMimeTypeIsText (mimeType);
		}
		
		public IDocumentInformation Current {
			get {
				if (curIndex < 0 || curIndex >= files.Count) {
					return null;
				}
				
				string fileName = files[curIndex];
				foreach (Document document in IdeApp.Workbench.Documents) {
					// WINDOWS DEPENDENCY: code insensitive check
					if (document.FileName != null && 0 == String.Compare (document.FileName, fileName, StringComparison.OrdinalIgnoreCase)) {
						IDocumentInformation doc = document.Window.ViewContent as IDocumentInformation;
						if (doc != null) return doc;
					}
				}
				return new FileDocumentInformation (fileName, 0);
			}
		}
		
		public bool MoveForward() 
		{
			while (++curIndex < files.Count)
				if (IsValid())
					return true;
			return false;
		}
		
		public bool MoveBackward()
		{
			if (curIndex == -1) {
				curIndex = files.Count - 1;
				return true;
			}
			while (--curIndex >= -1)
				if (IsValid())
					return true;
			return false;
		}
		
		public abstract void Reset();
	}
}
