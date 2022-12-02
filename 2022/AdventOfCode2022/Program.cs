using System;
using System.Collections.Generic;
using AdventOfCode2022.Day1;
using AdventOfCode2022.Day2;

namespace AdventOfCode2022 {
	class Program {
		//static void Main(string[] args) {
		//	string data = System.IO.File.ReadAllText("./Day1/input.txt");

		//	Console.WriteLine(data);
		//	CalorieCounter counter = new CalorieCounter();
		//	List<Elve> elves = counter.ParseElveCalorieData(data);
		//	int highest = counter.HighestCalorieCount(elves);
		//	Console.WriteLine("Highest calorie count on an elf: " + highest);
		//	int highestTop3 = counter.SumOfTopThreeCalorieCountElves(elves);
		//	Console.WriteLine("Calorie Count of the top three elves: " + highestTop3);
		//}

		static void Main(string[] args) {
			int total = 0;
			int totalColumnTwo = 0;
			RoundDeterminator determinator = new RoundDeterminator();
			MoveDecryptor decryptor = new MoveDecryptor();
			foreach(string str in System.IO.File.ReadLines("./Day2/input.txt")) {
				string[] strArr = str.Split(" ");
				total += determinator.CalculateRoundPoints(decryptor.ToMaterial(strArr[0]), decryptor.ToMaterial(strArr[1]));
				totalColumnTwo += determinator.CalculateRoundPoints(decryptor.ToMaterial(strArr[0]), decryptor.NeededMaterial(decryptor.NeededOutcomeDecryptor(strArr[1]),decryptor.ToMaterial(strArr[0])));
			}

			Console.WriteLine("Total: " + total);
			Console.WriteLine("Total with column 2: " + totalColumnTwo);


		}
	}
}

