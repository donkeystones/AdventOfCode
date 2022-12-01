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

	}
}
