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
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B"));

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
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B"));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("Study.txt", 1000));

			Assert.AreEqual(101000, dirManager.CurrentDirectory.GetDirectorySize());
		}

		[Test]
		public void SummaryOfDirectoryOneDirectoryOneFile() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B"));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 100000 } }, dirManager.GetAllFolderSizes());
		}

		[Test]
		public void SummaryOfDirectoryTwoDirectoriesOneFileInEach() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B"));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("A"));
			dirManager.CurrentDirectory.ChildDirectories[1].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 100000 }, { "A", 100000 } }, dirManager.GetAllFolderSizes());
		}

		[Test]
		public void SummaryOfDirectoryDirInDirOneFileInEach() {
			dirManager.ChangeCurrentDirectory(dirManager.RootDir);
			dirManager.CurrentDirectory.CreateChildDirectory(new Directory("B"));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateFile(new File("study.txt", 100000));
			dirManager.CurrentDirectory.ChildDirectories[0].CreateChildDirectory(new Directory("A"));
			dirManager.CurrentDirectory.ChildDirectories[0].ChildDirectories[0].CreateFile(new File("study.txt", 100000));

			Assert.AreEqual(new Dictionary<string, int>() { { "B", 200000 }, { "A", 100000 } }, dirManager.GetAllFolderSizes());
		}
	}
}
