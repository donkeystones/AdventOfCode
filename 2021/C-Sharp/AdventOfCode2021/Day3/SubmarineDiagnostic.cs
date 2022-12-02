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
				if (str != "") {
                    string temp = "";
                    for (int i = 0; i < str.Length; i++) {
						temp += str.Substring(i);
                    }
                    bitColumns.Add(str);
				}
			}
		}

		public int GetGamma() {
			return Convert.ToInt32(FilterGammaData(), 2);
		}

		public int GetEpsilon() {
			return Convert.ToInt32(FilterEpsilonData(), 2);
		}

		private int[] getCommonBits() {
            int[] commonBits = null;
            foreach (string str in bitColumns) {
                if (commonBits == null) {
                    commonBits = new int[str.Length];
                }
                char[] strArr = str.ToCharArray();

                for (int i = 0; i < strArr.Length; i++) {
                    if (strArr[i] == '1' && strArr[i] != '\r')
                        commonBits[i] += 1;
                    else
                        commonBits[i] -= 1;
                }
            }
			return commonBits;
        }

		private string FilterEpsilonData() {
			int[] commonBits = getCommonBits();
			string final = "";
			for(int i = 0;i < commonBits.Length;i++) {
				if(commonBits[i] < 0)
					final += "1";
				else
					final += "0";
			}
			return final;
		}

        private string FilterGammaData() {
            int[] commonBits = getCommonBits();
            string final = "";
            for (int i = 0; i < commonBits.Length; i++) {
                if (commonBits[i] > 0)
                    final += "1";
                else
                    final += "0";
            }
            return final;
        }

        public double GetEpsilonTimesGamma() {
			return GetEpsilon() * GetGamma();
		}
	}
}
