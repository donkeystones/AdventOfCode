using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day1 {
	public class DepthMeasurer {
		public List<Depth> ParseDepths(string data) {
			List<Depth> res = new List<Depth>();
			string[] dataArr = data.Split("\n");
			foreach(string str in dataArr) {
				if(str != "")
					res.Add(new Depth() { Measurement = int.Parse(str) });
			}

			return res;
		}

		public int TotalTimesDepthIncreases(List<Depth> depths) {
			int lastMeasure = depths[0].Measurement;
			int totalIncreasesOfDepth = 0;
			foreach(Depth depth in depths) {
				if(lastMeasure < depth.Measurement)
					totalIncreasesOfDepth++;
				lastMeasure = depth.Measurement;
			}
			return totalIncreasesOfDepth;
		}

		public List<Depth> ParseDepthsFiltered(string data) {
			List<Depth> depths = new List<Depth>();
			string[] dataArr = data.Split("\n");
			for(int i = 0; i < dataArr.Length - 2;i++) {
				if(dataArr[i] != "" && dataArr[i+1] != "" && dataArr[i+2] != "")
					depths.Add(new Depth() { Measurement = int.Parse(dataArr[i]) + int.Parse(dataArr[i + 1]) + int.Parse(dataArr[i + 2])});
			}
			return depths;
		}
	}
}
