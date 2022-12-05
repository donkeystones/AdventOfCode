using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day4;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day4 {
	public class CampSiteOrganizerTest {
		CampSiteOrganizer organizer;
		[SetUp]
		public void Setup() {
			organizer = new CampSiteOrganizer();
		}

		[Test]
		public void LoadDataOneCleaningPair() {
			string data = "36-92,35-78";

			organizer.LoadData(data);
			Assert.AreEqual(1, organizer.CleaningPairs.Count);
		}
	}
}
