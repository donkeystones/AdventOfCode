using System.Collections.Generic;
using AdventOfCode2022.Day1;
using NUnit.Framework;

namespace AdventOfCodeTest2022 {
	public class CalorieCounterTest {
		string data;
		CalorieCounter counter = new CalorieCounter();
		[SetUp]
		public void Setup() {
			
		}

		[Test]
		public void NewEmptyLineInDataShouldResultInANewElve() {
			data = "2000\n3000\n\n400\n300";
			List<Elve> elves = counter.ParseElveCalorieData(data);

			Assert.AreEqual(2, elves.Count);
		}

		[Test]
		public void TotalCalorieCountShouldBe500And200() {
			data = "200\n300\n\n80\n120";

			List<Elve> elves = counter.ParseElveCalorieData(data);
			Assert.AreEqual(500, elves[0].Calories);
			Assert.AreEqual(200, elves[1].Calories);
		}

		[Test]
		public void FiveThousandIsTheMostCaloriesAnElveIsCarrying() {
			data = "200\n100\n\n100\n100\n\n5000\n\n300\n\n600";
			List<Elve> elves = counter.ParseElveCalorieData(data);
			Assert.AreEqual(5000, counter.HighestCalorieCount(elves));
		}

		[Test]
		public void SumOfTopThreeCalorieCountOnElve() {
			data = "200\n\n300\n\n5000\n\n100\n\n6000\n\n200\n\n4000";
			List<Elve> elves = counter.ParseElveCalorieData(data);
			Assert.AreEqual(15000, counter.SumOfTopThreeCalorieCountElves(elves));
		}


	}
}