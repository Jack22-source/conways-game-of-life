using ConwayGameOfLife.Test.Fakes;
using NUnit.Framework;
using System.Linq;

namespace ConwayGameOfLife.Test
{
    public class ConwayTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetBlinkerDataTest()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());
           
            //When 
            var result = conway.GetBlinkerData();
            var cell1 = result.Where(w => w.X == 2 && w.Y == 1).First();
            var cell2 = result.Where(w => w.X == 2 && w.Y == 2).First();
            var cell3 = result.Where(w => w.X == 2 && w.Y == 3).First();


            //Then
            Assert.AreEqual(25, result.Count);
            Assert.AreEqual(1, cell1.CurrentState);
            Assert.AreEqual(1, cell1.PreviousState);

            Assert.AreEqual(1, cell2.CurrentState);
            Assert.AreEqual(1, cell2.PreviousState);

            Assert.AreEqual(1, cell3.CurrentState);
            Assert.AreEqual(1, cell3.PreviousState);

        }

        [Test]
        public void GetBlinkerDataTest_OneChange()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());
            var result = conway.GetBlinkerData();
            //When 

            conway.DrawNextGeneration(result, 5, 5);

            var cell1 = result.Where(w => w.X == 1 && w.Y == 2).First();
            var cell2 = result.Where(w => w.X == 2 && w.Y == 2).First();
            var cell3 = result.Where(w => w.X == 3 && w.Y == 2).First();


            //Then
            Assert.AreEqual(25, result.Count);
            Assert.AreEqual(1, cell1.CurrentState);
            Assert.AreEqual(1, cell1.PreviousState);

            Assert.AreEqual(1, cell2.CurrentState);
            Assert.AreEqual(1, cell2.PreviousState);

            Assert.AreEqual(1, cell3.CurrentState);
            Assert.AreEqual(1, cell3.PreviousState);

        }

        [Test]
        public void BuildRandomBoardSizeTest_24()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());

            //When 
            var result = conway.BuildRandomBoard(4, 6);

            //Then
            Assert.AreEqual(24, result.Count);
        }

        [Test]
        public void BuildRandomBoardSizeTest_0Column_0Row()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());

            //When 
            var result = conway.BuildRandomBoard(0, 0);

            //Then
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BuildRandomBoardSizeTest_0Column_1Row()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());

            //When 
            var result = conway.BuildRandomBoard(1, 0);

            //Then
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void BuildRandomBoardSizeTest_1Column_0Row()
        {
            //Given
            Conway conway = new Conway(new FakeDisplay());

            //When 
            var result = conway.BuildRandomBoard(1, 0);

            //Then
            Assert.AreEqual(0, result.Count);
        }
    }
}