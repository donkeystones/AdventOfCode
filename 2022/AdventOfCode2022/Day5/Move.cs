using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day5 {
	public class Move {
		public int Amount { get; internal set; }
		public int FromStack { get; internal set; }
		public int ToStack { get; internal set; }
	}
}
