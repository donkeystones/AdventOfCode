using System;
using System.Collections.Generic;
using AdventOfCode2022.Day1;

namespace AdventOfCode2022 {
	class Program {
		static void Main(string[] args) {
			string data = System.IO.File.ReadAllText("./Day1/input.txt");

			Console.WriteLine(data);
			CalorieCounter counter = new CalorieCounter();
			List<Elve> elves = counter.ParseElveCalorieData(data);
			int highest = counter.HighestCalorieCount(elves);
			Console.WriteLine("Highest calorie count on an elf: " + highest);
			int highestTop3 = counter.SumOfTopThreeCalorieCountElves(elves);
			Console.WriteLine("Calorie Count of the top three elves: " + highestTop3);
		}
	}
}
