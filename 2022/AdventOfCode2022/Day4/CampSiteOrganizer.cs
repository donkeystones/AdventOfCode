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
				string[] strArr = str.Split(",");
				CleaningPairs.Add(new CleaningPair(strArr[0], strArr[1]));
			}
		}
	}
}
