using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day4 {
	public class CleaningPair {
		public CleaningPair(string firstRange, string secondRange) {
			int[] ranges = parseRanges(firstRange);
			FirstRange = new CleanRange() { Lower = ranges[0], Upper = ranges[1] };
			ranges = parseRanges(secondRange);
			SecondRange = new CleanRange() { Lower = ranges[0], Upper = ranges[1] };
		}

		public int[] parseRanges(string range) {
			string[] ranges = range.Split("-");
			return new int[] { int.Parse(ranges[0]), int.Parse(ranges[1]) };
		}
		public CleanRange FirstRange { get; set; }
		public CleanRange SecondRange { get; set; }

	}
}
