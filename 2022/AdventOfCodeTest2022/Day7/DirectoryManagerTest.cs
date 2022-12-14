using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day7;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day7 {
	public class DirectoryManagerTest {
		DirectoryManager dirManager;
		[SetUp]
		public void Setup() {
			dirManager = new DirectoryManager();
		}

		[Test]
		public void DirectoryManagerInit() {
			Assert.AreEqual("/",dirManager.RootDir.Name);
		}

		

		[Test]
		public void ChangeCurrentDirectory() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);

			Assert.AreEqual("/", dirManager.CurrentDirectory.Name);
		}

		[Test]
		public void CreateChildDir() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B", dirManager.RootDir));

			Assert.AreEqual("B", dirManager.CurrentDirectory.ChildDirectories[0].Name);
		}

		[Test]
		public void CreateFileInDirectory() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateFile(new File("asfd", 1234));
			Assert.AreEqual(1, dirManager.CurrentDirectory.Files.Count);
			Assert.AreEqual("asfd", dirManager.CurrentDirectory.Files[0].Name);
			Assert.AreEqual(1234, dirManager.CurrentDirectory.Files[0].Size);
		}

		[Test]
		public void GetDirectorySizeWithNoChildFoldersAndOneFile() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateFile(new File("asfd", 1234));

			Assert.AreEqual(1234, dirManager.CurrentDirectory.GetDirectorySize());
		}

		[Test]
		public void GetDirectorySizeWithNoChildFoldersAndNoFiles() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);

			Assert.AreEqual(0, dirManager.CurrentDirectory.GetDirectorySize());
		}

		[Test]
		public void GetDirectorySizeWithChildFoldersAndOneFileOnBoth() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);

			dirManager.CurrentDirectory.CreateFile(new File("study.txt", 100000));
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B", dirManager.RootDir));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("Study.txt", 1000));

			Assert.AreEqual(101000, dirManager.CurrentDirectory.GetDirectorySize());
		}

		[Test]
		public void SummaryOfDirectoryOneDirectoryOneFile() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B", dirManager.RootDir));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 100000 } }, dirManager.GetAllFolderSizes());
		}

		[Test]
		public void SummaryOfDirectoryTwoDirectoriesOneFileInEach() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B", dirManager.RootDir));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("A", dirManager.RootDir));
			dirManager.CurrentDirectory.ChildDirectories[1].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 100000 }, { "A", 100000 } }, dirManager.GetAllFolderSizes());
		}

		[Test]
		public void SummaryOfDirectoryDirInDirOneFileInEach() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B", dirManager.RootDir));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateChildDirectory(new Directory("A",dirManager.CurrentDirectory.ChildDirectories[0]));
			dirManager.CurrentDirectory.ChildDirectories[0].ChildDirectories[0].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 200000 }, { "A", 100000 } }, dirManager.GetAllFolderSizes());
		}

		[Test]
		public void ParseDataLineToCommands() {
			string data = "$ ls\ndir a";

			dirManager.ParseData(data);

			Assert.AreEqual(1, dirManager.Commands.Count);
		}

		[Test]
		public void ParseCommandCreateDir() {
			string data = "dir a";

			dirManager.ParseCommand(data);

			Assert.AreEqual("a", dirManager.Commands[0].Name);
			Assert.AreEqual(CommandType.CREATE_DIRECTORY, dirManager.Commands[0].Type);
		}

		[Test]
		public void ParseCommandCreateFile() {
			string data = "2222 avs.txt";

			dirManager.ParseCommand(data);

			Assert.AreEqual("avs.txt", dirManager.Commands[0].Name);
			Assert.AreEqual(CommandType.CREATE_FILE, dirManager.Commands[0].Type);
			Assert.AreEqual(2222, dirManager.Commands[0].Size);
		}

		[Test]
		public void ParseCommandChangeDir() {
			string data = "$ cd a";

			dirManager.ParseCommand(data);

			Assert.AreEqual("a", dirManager.Commands[0].Name);
			Assert.AreEqual(CommandType.CHANGE_DIRECTORY, dirManager.Commands[0].Type);
		}

		[Test]
		public void OneDirWithOneFileAndChangeDirectory() {
			string data = "$ ls\ndir a\n$ cd a\n$ ls\n2222 abc.txt";

			dirManager.ParseData(data);

			Assert.AreEqual(3, dirManager.Commands.Count);
			Assert.AreEqual(CommandType.CREATE_DIRECTORY, dirManager.Commands[0].Type);
			Assert.AreEqual("a", dirManager.Commands[0].Name);
			
			Assert.AreEqual(CommandType.CHANGE_DIRECTORY, dirManager.Commands[1].Type);
			Assert.AreEqual("a", dirManager.Commands[1].Name);

			Assert.AreEqual(CommandType.CREATE_FILE, dirManager.Commands[2].Type);
			Assert.AreEqual("abc.txt", dirManager.Commands[2].Name);
			Assert.AreEqual(2222, dirManager.Commands[2].Size);
		}

		[Test]
		public void ParseAOCTestCode() {
			string data = "$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd..\n$ cd..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";


			dirManager.ParseData(data);

			Assert.AreEqual(18, dirManager.Commands.Count);
		}

		[Test]
		public void AllFolderSizesOfTestCode() {
			string data = "$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd..\n$ cd..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";

			dirManager.ParseData(data);
			dirManager.ExecuteCommands();
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
		}

		[Test]
		public void SumOfAllSizesLessThanHundredThousand() {
			string data = "$ ls\ndir a\n14848514 b.txt\n8504156 c.dat\ndir d\n$ cd a\n$ ls\ndir e\n29116 f\n2557 g\n62596 h.lst\n$ cd e\n$ ls\n584 i\n$ cd..\n$ cd..\n$ cd d\n$ ls\n4060174 j\n8033020 d.log\n5626152 d.ext\n7214296 k";

			dirManager.ParseData(data);
			dirManager.ExecuteCommands();
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			Assert.AreEqual(95437, dirManager.SumOfFolders());
		}

	}
}
