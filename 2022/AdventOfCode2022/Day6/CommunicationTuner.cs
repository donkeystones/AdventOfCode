using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022 {
	public class CommunicationTuner {
		public int GetStartOfPacketMarkerIndex(string data) {
			for(int i = 0;i < data.Length;i++) {
				if(!allCharactersSame(data.Substring(i, 4)))
					return i + 4;
			}
			return -1;
		}

		static bool allCharactersSame(string s) {
			int n = s.Length;
			for(int i = 0;i < n;i++)
				for(int j = 0;j < n;j++)
					if(s[i] == s[j] && i != j)
						return true;

			return false;
		}

		public int GetStartOfMessageMarkerIndex(string data) {
			for(int i = 0;i < data.Length;i++) {
				if(!allCharactersSame(data.Substring(i, 14)))
					return i + 14;
			}
			return -1;
		}
	}
}
