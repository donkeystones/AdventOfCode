using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2022.Day7 {

	public class DirectoryManager {
		public List<Command> Commands { get; internal set; }
		public DirectoryManager() {
			Commands = new List<Command>();
			RootDir = new Directory("/", null);
		}
		public Directory RootDir { get; internal set; }
		public Directory CurrentDirectory { get; internal set; }

		public void ChangeCurrentDirectory(Directory rootDir) {
			CurrentDirectory = rootDir;
		}

		public Dictionary<string, int> GetAllFolderSizes() {
			Dictionary<string, int> dirsAndSize = new Dictionary<string, int>();
			RootDir.ChildDirectories.ForEach(dir => {
				dirsAndSize = dir.GetDirectorySize(dirsAndSize);
			});
			return dirsAndSize;
		}

		public void ParseData(string data) {
			string[] dataArr = data.Split("\n");
			foreach(string command in dataArr) {
				ParseCommand(command);
			}
		}

		public void ParseCommand(string command) {
			if(command == "")
				return;
			string[] commandArr = command.Split(" ");

			if(commandArr[0] == "dir")
				Commands.Add(new Command() {
					Name = commandArr[1],
					Type = CommandType.CREATE_DIRECTORY
				});
			else if(commandArr[0] == "$") {
				if(commandArr[1] == "cd")
					Commands.Add(new Command() {
						Name = commandArr[2],
						Type = CommandType.CHANGE_DIRECTORY
					});
				else if(commandArr[1] == "cd..")
					Commands.Add(new Command() {
						Name = "..",
						Type = CommandType.CHANGE_DIRECTORY
					});
			} else {
				Commands.Add(new Command() {
					Name = commandArr[1],
					Size = int.Parse(commandArr[0]),
					Type = CommandType.CREATE_FILE
				});
			}
		}

		public void ExecuteCommands() {
			CurrentDirectory = RootDir;
			foreach(Command command in Commands) {
				switch(command.Type) {
					case CommandType.CREATE_DIRECTORY:
						CurrentDirectory.CreateChildDirectory(new Directory(command.Name, CurrentDirectory));
						break;
					case CommandType.CREATE_FILE:
						CurrentDirectory.CreateFile(new File(command.Name, command.Size));
						break;
					case CommandType.CHANGE_DIRECTORY: //Should probably rewrite changeDirectory to handle ".." in the actual method...
						ChangeCurrentDirectory(command.Name == ".." ? CurrentDirectory.ParentDirectory : CurrentDirectory.ChildDirectories.Find(dir => dir.Name == command.Name));
						break;
				default: break;
				}
			}
		}

		public int SumOfFolders() {
			int total = 0;
			foreach(KeyValuePair<string, int> dir in GetAllFolderSizes()) {
				if(dir.Value < 100000)
					total += dir.Value;
			}
			return total;
		}

		public int FolderRequiredToDelete() {
			int total = 0;
			foreach(KeyValuePair<string, int> dir in GetAllFolderSizes()) {
				total += dir.Value;
				if(dir.Value > 8381165)
					Console.WriteLine(dir.Key + ": " + dir.Value);
			}
			return total;
		}
	}
}
