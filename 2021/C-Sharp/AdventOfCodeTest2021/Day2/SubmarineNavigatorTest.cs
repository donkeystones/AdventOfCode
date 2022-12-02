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
            Assert.AreEqual(5, subNav.GetCoordinates().Aim);
        }

        [Test]
        public void MoveUpDecreasesDepthAxis() {
            subNav.ResetCoordinates();
            subNav.MoveDown(5);
            subNav.MoveUp(2);
            Assert.AreEqual(3, subNav.GetCoordinates().Aim);
        }

        [Test]
        public void LoadCommandsWithStringShouldResultInSixCommands() {
            string commands = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            subNav.LoadCommands(commands);
            Assert.AreEqual(6, subNav.Commands.Count);
        }

        [Test]
        public void DriveShouldResultInDepthTenAndHorizontalFifteen() {
            string commands = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            subNav.LoadCommands(commands);
            subNav.Drive();
            Assert.AreEqual(15, subNav.GetCoordinates().X);
            Assert.AreEqual(60, subNav.GetCoordinates().Y);
        }

        [Test]
        public void GetDuplicationOfXAndY() {
            string commands = "forward 5\ndown 5\nforward 8\nup 3\ndown 8\nforward 2";
            subNav.LoadCommands(commands);
            subNav.Drive();
            Assert.AreEqual(900, subNav.GetMultiplicationOfXAndY());
        }
    }
}
