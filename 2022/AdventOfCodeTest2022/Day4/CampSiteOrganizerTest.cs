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
		[Test]
		public void LoadDataTwoCleaningPairs() {
			string data = "36-92,35-78\n1-2,2-4";

			organizer.LoadData(data);
			Assert.AreEqual(2, organizer.CleaningPairs.Count);
		}

		[Test]
		public void FirstRangeIsOverlappingSecondRange() {
			string data = "2-8,3-7";

			organizer.LoadData(data);
			Assert.AreEqual(true, organizer.IsOverlapping(organizer.CleaningPairs[0]));
		}

		[Test]
		public void SecondRangeIsOverlappingFirstRange() {
			string data = "3-7,2-8";

			organizer.LoadData(data);
			Assert.AreEqual(true, organizer.IsOverlapping(organizer.CleaningPairs[0]));
		}
		[Test]
		public void BothAreOverlapping() {
			string data = "2-8,2-8";

			organizer.LoadData(data);
			Assert.AreEqual(true, organizer.IsOverlapping(organizer.CleaningPairs[0]));
		}

		[Test]
		public void TotalOverlappingIsOne() {
			string data = "2-8,2-8\n1-2,3-5";

			organizer.LoadData(data);
			Assert.AreEqual(1, organizer.TotalOverlapping(false));
		}

		[Test]
		public void TotalOverlappingIsTwo() {
			string data = "2-8,2-8\n1-2,1-5";

			organizer.LoadData(data);
			Assert.AreEqual(2, organizer.TotalOverlapping(false));
		}

		[Test]
		public void TotalOverlappingFineSearchIsOne() {
			string data = "1-3,4-6\n1-2,2-3";

			organizer.LoadData(data);
			Assert.AreEqual(1, organizer.TotalOverlapping(true));
		}

		[Test]
		public void TotalOverlappingFineSearchIsNone() {
			string data = "1-3,4-6\n1-2,3-3";

			organizer.LoadData(data);
			Assert.AreEqual(0, organizer.TotalOverlapping(true));
		}

		[Test]
		public void TotalOverlappingFineSearchIsTwo() {
			string data = "1-3,2-6\n1-2,2-3";

			organizer.LoadData(data);
			Assert.AreEqual(2, organizer.TotalOverlapping(true));
		}

	}
}
