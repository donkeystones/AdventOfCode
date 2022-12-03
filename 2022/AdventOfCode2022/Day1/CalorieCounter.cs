using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day1 {
	public class CalorieCounter {
		public List<Elve> ParseElveCalorieData(string data) {
			string[] dataArr = data.Split("\n");
			List<Elve> res = ParseElveCalorieDataArr(dataArr);
			return res;
		}

		private List<Elve> ParseElveCalorieDataArr(string[] dataArr) {
			int calorieCount = 0;
			List<Elve> elves = new List<Elve>();
			foreach(string str in dataArr) {
				if(str == "") {
					elves.Add(new Elve() { Calories = calorieCount });
					calorieCount = 0;
				} else
					calorieCount += int.Parse(str);
			}
			elves.Add(new Elve() { Calories = calorieCount });
			return elves;
		}

		public int HighestCalorieCount(List<Elve> elves) {
			int highest = 0;
			foreach(Elve elve in elves) {
				if(elve.Calories > highest) {
					highest = elve.Calories;
				}
			}
			return highest;
		}

		public int SumOfTopThreeCalorieCountElves(List<Elve> elves) {
			int[] topThree = new int[] { 0, 0, 0 };
			foreach(Elve elve in elves) {
				if(elve.Calories > topThree[0]) {
					topThree[2] = topThree[1];
					topThree[1] = topThree[0];
					topThree[0] = elve.Calories;
				} else if(elve.Calories == topThree[0] || elve.Calories > topThree[1]) {
					topThree[2] = topThree[1];
					topThree[1] = elve.Calories;
				} else if(elve.Calories == topThree[1] || elve.Calories > topThree[2]) {
					topThree[2] = elve.Calories;
				}
			}
			return topThree[0] + topThree[1] + topThree[2];
		}
	}
}
