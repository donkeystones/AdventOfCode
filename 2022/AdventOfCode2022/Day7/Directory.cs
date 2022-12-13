using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Day7 {
	public class Directory {
		public Directory ParentDirectory { get; internal set; }
		public List<Directory> ChildDirectories;
		public List<File> Files;
		public Directory(string name, Directory parent) {
			ParentDirectory = parent;
			Files = new List<File>();
			ChildDirectories = new List<Directory>();
			Name = name;
		}
		public string Name { get; internal set; }

		public void CreateChildDirectory(Directory directory) {
			ChildDirectories.Add(directory);
		}

		public void CreateFile(File file) {
			Files.Add(file);
		}

		public int GetDirectorySize() {
			int total = 0;
			if(Files.Count == 0 && ChildDirectories.Count == 0)
				return 0;
			if(ChildDirectories.Count != 0)
				total += ChildDirectories.Sum(dir => dir.GetDirectorySize());
			total += Files.Sum(file => file.Size);
			return total;
		}

		internal Dictionary<string, int> GetDirectorySize(Dictionary<string, int> dirsAndSize) {
			dirsAndSize.Add(Name, GetDirectorySize());
			ChildDirectories.ForEach(dir => {
				dirsAndSize = dir.GetDirectorySize(dirsAndSize);
			});
			return dirsAndSize;
		}
	}
}
