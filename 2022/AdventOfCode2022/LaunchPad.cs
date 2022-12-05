using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day1;
using AdventOfCode2022.Day2;
using AdventOfCode2022.Day3;
using AdventOfCode2022.Day4;

namespace AdventOfCode2022 {
	public class LaunchPad {
		public void Day1() {
			string data = System.IO.File.ReadAllText("./Day1/input.txt");

			Console.WriteLine(data);
			CalorieCounter counter = new CalorieCounter();
			List<Elve> elves = counter.ParseElveCalorieData(data);
			int highest = counter.HighestCalorieCount(elves);
			Console.WriteLine("Highest calorie count on an elf: " + highest);
			int highestTop3 = counter.SumOfTopThreeCalorieCountElves(elves);
			Console.WriteLine("Calorie Count of the top three elves: " + highestTop3);
		}

		public void Day2() {
			int total = 0;
			int totalColumnTwo = 0;
			RoundDeterminator determinator = new RoundDeterminator();
			MoveDecryptor decryptor = new MoveDecryptor();
			foreach(string str in System.IO.File.ReadLines("./Day2/input.txt")) {
				string[] strArr = str.Split(" ");
				total += determinator.CalculateRoundPoints(decryptor.ToMaterial(strArr[0]), decryptor.ToMaterial(strArr[1]));
				totalColumnTwo += determinator.CalculateRoundPoints(decryptor.ToMaterial(strArr[0]), decryptor.NeededMaterial(decryptor.NeededOutcomeDecryptor(strArr[1]), decryptor.ToMaterial(strArr[0])));
			}

			Console.WriteLine("Total: " + total);
			Console.WriteLine("Total with column 2: " + totalColumnTwo);
		}

		public void Day3() {
			string data = "";
			foreach(string str in System.IO.File.ReadLines("./Day3/input.txt")) {
				data += str + "\r\n";
			}

			RuckSackOrganizer ruckSackOrganizer = new RuckSackOrganizer();
			ruckSackOrganizer.LoadRuckSack(data);
			Console.WriteLine(ruckSackOrganizer.GetSumOfDuplicatesInRuckSacks());
			Console.WriteLine(ruckSackOrganizer.GetSumOfItemInThreeRucksacks());
		}

		public void Day4() {
			string data = "";
			foreach(string str in System.IO.File.ReadLines("./Day4/input.txt")) {
				data += str + "\n";
			}

			CampSiteOrganizer organizer = new CampSiteOrganizer();
			organizer.LoadData(data);
			Console.WriteLine("Total cleaning pairs overlapping: " + organizer.TotalOverlapping(false));
			Console.WriteLine("Total cleaning pairs overlapping (fine search): " + organizer.TotalOverlapping(true));

		}

		public void Day5() {

		}
	}

	
}
