using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestElf()
        {
            Elf p1 = new Elf();
            Player j1 = new Player(p1, 6, "Delphine");
            Assert.IsTrue(j1.getFaction() is Elf);
        }

        [TestMethod]
        public void TestDwarf()
        {
            Dwarf p2 = new Dwarf();
            Player j2 = new Player(p2, 15, "Mathieu");
            Assert.IsTrue(j2.getFaction() is Dwarf);
        }

        [TestMethod]
        public void TestHuman()
        {
            Human p1 = new Human();
            Player j1 = new Player(p1, 6, "Delphine");
            Assert.IsTrue(j1.getFaction() is Human);
        }

        [TestMethod]
        public void TestOrc()
        {
            Orc p2 = new Orc();
            Player j2 = new Player(p2, 15, "Mathieu");
            Assert.IsTrue(j2.getFaction() is Orc);
        }

        [TestMethod]
        public void TestGenerationMapDemo()
        {

            Map map = new MapDemo();
            Assert.IsTrue(map.getSize() == 5);

        }

        [TestMethod]
        public void TestGenerationMapSmall()
        {

            Map map = new MapSmall();
            Assert.IsTrue(map.getSize() == 10);

        }

        [TestMethod]
        public void TestGenerationMapNormal()
        {

            Map map = new MapNormal();
            Assert.IsTrue(map.getSize() == 15);

        }

        [TestMethod]
        public void TestGetTile()
        {
            Map map = new MapDemo();
            map.getTile(0, 0);

        }

        [TestMethod]
        public void TestGame()
        {
            Dwarf p2 = new Dwarf();
            Player j2 = new Player(p2, 15, "Mathieu");
            Elf p1 = new Elf();
            Player j1 = new Player(p1, 6, "Delphine");
            Map map = new MapSmall();
            Game game = new Game(20, j1, j2, map);
        }



        [TestMethod]
        public void TestTileFactory()
        {
            ITileFactory f = new ITileFactory();
            Assert.IsTrue(f.makeTile(1) is TileDesert);
            Assert.IsTrue(f.makeTile(2) is TileForest);
            Assert.IsTrue(f.makeTile(3) is TileMountain);
            Assert.IsTrue(f.makeTile(4) is TilePlain);
            Assert.IsTrue(f.makeTile(5) is TileMarsh);
        }

       
    }
}
