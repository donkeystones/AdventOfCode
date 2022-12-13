using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day7 {

	public class DirectoryManager {
		public DirectoryManager() {
			RootDir = new Directory("/");
		}
		public Directory RootDir { get; internal set; }
		public Directory CurrentDirectory { get; internal set; }

		public void ChangeCurrentDirectory(Directory rootDir) {
			CurrentDirectory = rootDir;
		}

		public Dictionary<string, int> GetAllFolderSizes() {
			Dictionary<string, int> dirsAndSize = new Dictionary<string, int>();
			RootDir.ChildDirectories.ForEach(dir => {
				dirsAndSize = dir.GetDirectorySize(dirsAndSize);
			});
			return dirsAndSize;
		}
	}
}
