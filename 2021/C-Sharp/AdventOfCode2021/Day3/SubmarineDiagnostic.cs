using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day3 {
	public class SubmarineDiagnostic {
		List<string> bitColumns = new List<string>();
		int Gamma, Epsilon;
		public void LoadData(string data) {
			string[] dataArr = data.Split("\n");
			foreach(string str in dataArr) {
				if(str != "")
					bitColumns.Add(str);
			}
		}

		public int GetGamma() {
			return Convert.ToInt32(FilterGammaData(), 2);
		}

		public int GetEpsilon() {
			return Convert.ToInt32(FilterEpsilonData(), 2);
		}

		private string FilterEpsilonData() {
			int[] commonBits = new int[] { 0, 0, 0, 0, 0, 0, 0 };
			foreach(string str in bitColumns) {
				char[] strArr = str.ToCharArray();

				if(strArr[0] == '1')
					commonBits[0] += 1;
				else
					commonBits[0] -= 1;
				if(strArr[1] == '1')
					commonBits[1] += 1;
				else
					commonBits[1] -= 1;
				if(strArr[2] == '1')
					commonBits[2] += 1;
				else
					commonBits[2] -= 1;
				if(strArr[3] == '1')
					commonBits[3] += 1;
				else
					commonBits[3] -= 1;
				if(strArr[4] == '1')
					commonBits[4] += 1;
				else
					commonBits[4] -= 1;
				if(strArr[5] == '1')
					commonBits[5] += 1;
				else
					commonBits[5] -= 1;
				if(strArr[6] == '1')
					commonBits[6] += 1;
				else
					commonBits[6] -= 1;

			}
			string final = "";
			for(int i = 0;i <= 6;i++) {
				if(commonBits[i] < 0)
					final += "1";
				else
					final += "0";
			}
			return final;
		}

		public double GetEpsilonTimesGamma() {
			return GetEpsilon() * GetGamma();
		}

		private string FilterGammaData() {
			int[] commonBits = new int[] { 0, 0, 0, 0, 0, 0, 0 };
			foreach(string str in bitColumns) {
				char[] strArr = str.ToCharArray();

				if(strArr[0] == '1')
					commonBits[0] += 1;
				else
					commonBits[0] -= 1;
				if(strArr[1] == '1')
					commonBits[1] += 1;
				else
					commonBits[1] -= 1;
				if(strArr[2] == '1')
					commonBits[2] += 1;
				else
					commonBits[2] -= 1;
				if(strArr[3] == '1')
					commonBits[3] += 1;
				else
					commonBits[3] -= 1;
				if(strArr[4] == '1')
					commonBits[4] += 1;
				else
					commonBits[4] -= 1;
				if(strArr[5] == '1')
					commonBits[5] += 1;
				else
					commonBits[5] -= 1;
				if(strArr[6] == '1')
					commonBits[6] += 1;
				else
					commonBits[6] -= 1;
			}
			string final = "";
			for(int i = 0; i <= 6;i++) {
				if(commonBits[i] > 0)
					final += "1";
				else
					final += "0";
			}
			return final;
		}
	}
}
