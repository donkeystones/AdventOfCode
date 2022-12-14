using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day7 {
	public enum CommandType {
		CREATE_DIRECTORY,
		CREATE_FILE,
		CHANGE_DIRECTORY
	}
	public class Command {
		public CommandType Type { get; set; }
		public string Name { get; set; }
		public int Size { get; set; }
	}
}
