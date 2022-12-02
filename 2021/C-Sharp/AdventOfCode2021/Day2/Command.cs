using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day2 {
	public enum Direction {
		FORWARD,
		DOWN,
		UP,
		INVALID
	}
	public class Command {
		public Direction Direction { get; internal set; }
		public int Length { get; internal set; }
	}
}
