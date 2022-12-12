using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day7 {
<<<<<<< Updated upstream
    public class DirectoryManager {
    }
=======
	public class DirectoryManager {
		public DirectoryManager() {
			RootDir = new Directory("/");
		}
		public Directory RootDir { get; internal set; }
		public Directory CurrentDirectory { get; internal set; }

		public void ChangeCurrentDirectory(Directory rootDir) {
			CurrentDirectory = rootDir;
		}
	}
>>>>>>> Stashed changes
}
