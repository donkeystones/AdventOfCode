using AdventOfCode2021.Day2;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCodeTest2021.Day2
{
    public class SubmarineNavigatorTest
    {
        SubmarineNavigator subNav;

        [SetUp]
        public void Setup() {
            subNav = new SubmarineNavigator();
        }

        [Test]
        public void MoveForwardIncreasesHorizontalAxis() {
            subNav.ResetCoordinates();
            subNav.MoveForward(5);
            Assert.AreEqual(5, subNav.GetCoordinates().X);
        }

        [Test]
        public void MoveDownIncreasesDepthAxis() {
            subNav.ResetCoordinates();
            subNav.MoveDown(5);
            Assert.AreEqual(5, subNav.GetCoordinates().Y);
        }

        [Test]
        public void MoveUpDecreasesDepthAxis() {
            subNav.ResetCoordinates();
            subNav.MoveDown(5);
            subNav.MoveUp(2);
            Assert.AreEqual(3, subNav.GetCoordinates().Y);
        }

        [Test]
        public void CommandParserShouldResultInChangedCoordinates() {
            string commands = "forward 5\ndown 5\nforward\nup 3\ndown 8\forward 2";

        }
    }
}
