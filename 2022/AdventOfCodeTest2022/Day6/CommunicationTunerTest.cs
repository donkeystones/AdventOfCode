using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day6 {
	public class CommunicationTunerTest {
		CommunicationTuner tuner;
		[SetUp]
		public void Setup() {
			tuner = new CommunicationTuner();
		}
		[Test]
		public void StartOfTransmitionIndexTestOne() {
			string data = "bvwbjplbgvbhsrlpgdmjqwftvncz";

			Assert.AreEqual(5, tuner.GetStartOfPacketMarkerIndex(data));
		}
		[Test]
		public void StartOfTransmitionIndexTestTwo() {
			string data = "nppdvjthqldpwncqszvftbrmjlhg";

			Assert.AreEqual(6, tuner.GetStartOfPacketMarkerIndex(data));
		}
		[Test]
		public void StartOfTransmitionIndexTestThree() {
			string data = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";

			Assert.AreEqual(10, tuner.GetStartOfPacketMarkerIndex(data));
		}
		[Test]
		public void StartOfTransmitionIndexTestFour() {
			string data = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";

			Assert.AreEqual(11, tuner.GetStartOfPacketMarkerIndex(data));
		}

		[Test]
		public void StartOfMessageIndexTestOne() {
			string data = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";

			Assert.AreEqual(19, tuner.GetStartOfMessageMarkerIndex(data));
		}
		[Test]
		public void StartOfMessageIndexTestTwo() {
			string data = "bvwbjplbgvbhsrlpgdmjqwftvncz";

			Assert.AreEqual(23, tuner.GetStartOfMessageMarkerIndex(data));
		}
		[Test]
		public void StartOfMessageIndexTestThree() {
			string data = "nppdvjthqldpwncqszvftbrmjlhg";

			Assert.AreEqual(23, tuner.GetStartOfMessageMarkerIndex(data));
		}
		[Test]
		public void StartOfMessageIndexTestFour() {
			string data = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";

			Assert.AreEqual(29, tuner.GetStartOfMessageMarkerIndex(data));
		}
		[Test]
		public void StartOfMessageIndexTestFive() {
			string data = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";

			Assert.AreEqual(26, tuner.GetStartOfMessageMarkerIndex(data));
		}
	}
}
