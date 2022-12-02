using System;
using System.Collections.Generic;
using AdventOfCode2021.Day1;
using AdventOfCode2021.Day2;
using AdventOfCode2021.Day3;

namespace AdventOfCode2021 {
	class Program {
		//static void Main(string[] args) {
		//	string data = System.IO.File.ReadAllText("./Day1/input.txt");
		//	DepthMeasurer depthMeasurer = new DepthMeasurer();
		//	List<Depth> depths = depthMeasurer.ParseDepths(data);
		//	List<Depth> depthsFiltered = depthMeasurer.ParseDepthsFiltered(data);
		//	Console.WriteLine("Total number of time depth has increased is " + depthMeasurer.TotalTimesDepthIncreases(depths) + " times!");
		//	Console.WriteLine("Total number of time depth has increased with the filter on is " + depthMeasurer.TotalTimesDepthIncreases(depthsFiltered) + " times!");
		//}

		//static void Main(string[] args) {
		//	string data = System.IO.File.ReadAllText("./Day2/input.txt");
		//	SubmarineNavigator navigator = new SubmarineNavigator();
		//	navigator.LoadCommands(data);
		//	navigator.Drive();
		//	Console.WriteLine("Final coordinates are:\n" + "X: " + navigator.GetCoordinates().X + "\nY: " + navigator.GetCoordinates().Y);
		//	Console.Write("X * Y = " + navigator.GetMultiplicationOfXAndY());
		//}

		static void Main(string[] args) {
			string data = System.IO.File.ReadAllText("./Day3/input.txt");
			Console.WriteLine(data);
			SubmarineDiagnostic subdiagnostic = new SubmarineDiagnostic();
			subdiagnostic.LoadData(data);
			Console.WriteLine("Epsilon: " + subdiagnostic.GetEpsilon());
			Console.WriteLine("Gamma: " + subdiagnostic.GetGamma());
			Console.WriteLine("Epsilon*Gamma: " + subdiagnostic.GetEpsilonTimesGamma());
		}
	}
}
