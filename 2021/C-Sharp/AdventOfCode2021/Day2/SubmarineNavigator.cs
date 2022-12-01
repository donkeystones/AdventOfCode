using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day2
{
    public class SubmarineNavigator {
        private Coordinate _coordinates;
        public SubmarineNavigator() {
            ResetCoordinates();
        }

        public void ResetCoordinates() {
            _coordinates = new Coordinate() { X = 0, Y = 0 };
        }

        public Coordinate GetCoordinates() {
            return _coordinates;
        }

        public void MoveUp(int verticalMovement) {
            _coordinates.Y -= verticalMovement;
        }

        public void MoveDown(int verticalMovement) {
            _coordinates.Y += verticalMovement;
        }

        public void MoveForward(int horizontalMovement) {
            _coordinates.X += horizontalMovement;
        }
    }
}
