using System;
using System.Collections.Generic;
using AdventOfCode2021.Day1;

namespace AdventOfCode2021 {
	class Program {
		static void Main(string[] args) {
			string data = System.IO.File.ReadAllText("./Day1/input.txt");
			DepthMeasurer depthMeasurer = new DepthMeasurer();
			List<Depth> depths = depthMeasurer.ParseDepths(data);
			List<Depth> depthsFiltered = depthMeasurer.ParseDepthsFiltered(data);
			Console.WriteLine("Total number of time depth has increased is " + depthMeasurer.TotalTimesDepthIncreases(depths) + " times!");
			Console.WriteLine("Total number of time depth has increased with the filter on is " + depthMeasurer.TotalTimesDepthIncreases(depthsFiltered) + " times!");
		}
	}
}
