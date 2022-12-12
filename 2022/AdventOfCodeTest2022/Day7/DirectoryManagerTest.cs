using System;
using System.Collections.Generic;
using System.Text;
using AdventOfCode2022.Day7;
using NUnit.Framework;

namespace AdventOfCodeTest2022.Day7 {
	public class DirectoryManagerTest {
<<<<<<< Updated upstream
        DirectoryManager dirManager;
        [SetUp]
		public void Setup() {
			dirManager = new DirectoryManager();
		}
		[Test]
		public void CreateDir() {
			dirManager.
=======
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
>>>>>>> Stashed changes
		}
	}
}
