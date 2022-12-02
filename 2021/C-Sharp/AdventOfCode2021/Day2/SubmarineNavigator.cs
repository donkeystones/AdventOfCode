using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2021.Day2
{
    public class SubmarineNavigator {
        private Coordinate _coordinates;
        public List<Command> Commands { get; internal set; }
        public SubmarineNavigator() {
            ResetCoordinates();
            Commands = new List<Command>();
        }

        public void ResetCoordinates() {
            _coordinates = new Coordinate() { X = 0, Y = 0, Aim = 0 };
        }

        public Coordinate GetCoordinates() {
            return _coordinates;
        }

        public void MoveUp(int verticalMovement) {
            _coordinates.Aim -= verticalMovement;
        }

        public void MoveDown(int verticalMovement) {
            _coordinates.Aim += verticalMovement;
        }

        public void MoveForward(int horizontalMovement) {
            _coordinates.X += horizontalMovement;
            _coordinates.Y += (_coordinates.Aim * horizontalMovement);
        }

		public void LoadCommands(string commands) {
            string[] commandsArray = commands.Split("\n");
            foreach(string command in commandsArray) {
                string[] commandArr = command.Split(" ");
                if(commandArr[0] != "" && commandArr[1] != "")
                    Commands.Add(new Command() {
                        Direction = ParseDirection(commandArr[0]),
                        Length = int.Parse(commandArr[1])
                    });
			}
		}

        private Direction ParseDirection(string dir) {
            if(dir == "forward")
                return Direction.FORWARD;
            else if(dir == "down")
                return Direction.DOWN;
            else if(dir == "up")
                return Direction.UP;
            return Direction.INVALID;
		}

		public void Drive() {
			foreach(Command command in Commands) {
                if(command.Direction == Direction.FORWARD)
                    MoveForward(command.Length);
                else if(command.Direction == Direction.DOWN)
                    MoveDown(command.Length);
                else if(command.Direction == Direction.UP)
                    MoveUp(command.Length);
            }
		}

		public int GetMultiplicationOfXAndY() {
            return _coordinates.X * _coordinates.Y;
		}
	}
}
