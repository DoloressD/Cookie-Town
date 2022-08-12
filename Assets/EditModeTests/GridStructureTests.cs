using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

//this is for Unity Testing
namespace Tests
{
    public class GridStructureTests
    {
        GridStructure structure;
        [OneTimeSetUp]
        public void Init()
		{
            structure = new GridStructure(3,100,100);
        }

		#region GridPositionTests
		// A Test behaves as an ordinary method
		[Test]
        public void CalculateGridPositionPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero , returnPosition);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void CalculateGridPositionFloatsPasses()
        {
            Vector3 position = new Vector3(2.9f, 0, 2.9f);

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreEqual(Vector3.zero, returnPosition);
        }

        [Test]
        public void CalculateGridPositionFail()
        {
            Vector3 position = new Vector3(3.1f, 0, 0);

            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);

            //Assert
            Assert.AreNotEqual(Vector3.zero, returnPosition);
        }

		#endregion

		#region GridIndexTests
        [Test]
        public void PlaceStructure303AndCheckIsTakenPasses()
		{
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
		}

        [Test]
        public void PlaceStructureMINAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(0, 0, 0);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructureMAXAndCheckIsTakenPasses()
        {
            Vector3 position = new Vector3(297, 0, 297);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = new GameObject("TestGameObject");
            structure.PlaceStructureOnGrid(testGameObject, position);
            //Assert
            Assert.IsTrue(structure.IsCellTaken(position));
        }


        [Test]
        public void PlaceStructure303AndCheckIsTakenNullObjectShouldFail()
        {
            Vector3 position = new Vector3(3, 0, 3);
            //Act
            Vector3 returnPosition = structure.CalculateGridPosition(position);
            GameObject testGameObject = null;
            structure.PlaceStructureOnGrid(testGameObject, position);
            //Assert
            Assert.IsFalse(structure.IsCellTaken(position));
        }

        [Test]
        public void PlaceStructureAndCheckIsTakenIndexOutOfBoundsFail()
        {
            Vector3 position = new Vector3(303, 0, 303);
            //Act    
            //Assert
            Assert.Throws<IndexOutOfRangeException>(() => structure.IsCellTaken(position));
        }
        #endregion
    }
}
