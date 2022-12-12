using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2022.Day7 {
	public class Directory {
		public List<Directory> ChildDirectories;
		public List<File> Files;
		public Directory(string name) {
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

		public double GetDirectorySize() {
			if(Files.Count == 0 && ChildDirectories.Count == 0)
				return 0;
			return Files.Sum(file => file.Size);
		}
	}
}
