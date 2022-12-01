using System.Collections.Generic;
using AdventOfCode2021.Day1;
using NUnit.Framework;

namespace AdventOfCodeTest2021.Day1 {
	public class DepthMeasurerTest {
		DepthMeasurer depthMeasurer;

		[SetUp]
		public void Setup() {
			depthMeasurer = new DepthMeasurer();
		}

		[Test]
		public void ParseDepthDataNewLineIsNewMeasurement() {
			string data = "200\n201\n202";

			List<Depth> depths = depthMeasurer.ParseDepths(data);
			Assert.AreEqual(3, depths.Count);
		}

		[Test]
		public void DepthIncreaseShouldBeTwo() {
			string data = "200\n201\n202";

			List<Depth> depths = depthMeasurer.ParseDepths(data);
			Assert.AreEqual(2, depthMeasurer.TotalTimesDepthIncreases(depths));
		}

		[Test]
		public void DepthIncreaseTotalShouldBeZeroIfDepthIsOnlyShallower() {
			string data = "200\n199\n198";

			List<Depth> depths = depthMeasurer.ParseDepths(data);
			Assert.AreEqual(0, depthMeasurer.TotalTimesDepthIncreases(depths));
		}

		[Test]
		public void ParseDepthsFilteredThreeValuesShouldResultInOneMeasurement() {
			string data = "200\n201\n202";

			List<Depth> depths = depthMeasurer.ParseDepthsFiltered(data);
			Assert.AreEqual(1, depths.Count);
			Assert.AreEqual(603, depths[0].Measurement);
		}

		[Test]
		public void ParseDepthsFilteredFiveValuesShouldGiveThreeMeasurements() {
			string data = "200\n201\n202\n203\n204";

			List<Depth> depths = depthMeasurer.ParseDepthsFiltered(data);
			Assert.AreEqual(3, depths.Count);
		}

		[Test]
		public void ParseDepthsFilteredIncreasesThreeTimes() {
			string data = "200\n201\n200\n203\n204\n208";

			List<Depth> depths = depthMeasurer.ParseDepthsFiltered(data);

			Assert.AreEqual(3, depthMeasurer.TotalTimesDepthIncreases(depths));
		}
	}
}