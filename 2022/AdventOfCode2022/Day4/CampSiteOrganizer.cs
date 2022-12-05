using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day4 {
	public class CampSiteOrganizer {
		public List<CleaningPair> CleaningPairs { get; set; }

		public CampSiteOrganizer() {
			CleaningPairs = new List<CleaningPair>();
		}
		public void LoadData(string data) {
			string[] dataArr = data.Split("\n");
			foreach(string str in dataArr) {
				if(str != "") {
					string[] strArr = str.Split(",");
					CleaningPairs.Add(new CleaningPair(strArr[0], strArr[1]));
				}
			}
		}

		private bool IsOverlappingFineSearch(CleaningPair cleanPair) {
			return cleanPair.FirstRange.Lower <= cleanPair.SecondRange.Upper && cleanPair.SecondRange.Lower <= cleanPair.FirstRange.Upper;
		}

		public bool IsOverlapping(CleaningPair cleaningPair) {
			return (cleaningPair.FirstRange.Lower <= cleaningPair.SecondRange.Lower &&
				cleaningPair.FirstRange.Upper >= cleaningPair.SecondRange.Upper) ||
				(cleaningPair.SecondRange.Lower <= cleaningPair.FirstRange.Lower &&
				cleaningPair.SecondRange.Upper >= cleaningPair.FirstRange.Upper);
		}

		public int TotalOverlapping(bool fineSearch) {
			int total = 0;
			foreach(CleaningPair cleanPair in CleaningPairs) {
				if(fineSearch ? IsOverlappingFineSearch(cleanPair) : IsOverlapping(cleanPair))
					total++;
			}
			return total;
		}

	}
}
