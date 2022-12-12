using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day7 {
	public class File {
		public File(string name, int size) {
			Name = name;
			Size = size;
		}
		public string Name { get; internal set; }
		public int Size { get; internal set; }
	}
}
