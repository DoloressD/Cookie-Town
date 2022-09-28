using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class StructureHolderTests
    {
        StructureHolder structureHolder;
        [OneTimeSetUp]

        public void Init()
		{
            StructureCollectionsSO collection = new StructureCollectionsSO();
            var road =new RoadStructureSO();
            road.buildingName = "Road";
            var facility = new SingleFacilitySO();
            facility.buildingName = "Power Plant";
            var zone = new ZoneStructureSO();
            zone.buildingName = "Commercial";

            collection.roadStructure = road;
            collection.singleStructureList = new List<SingleStructureBaseSO>();
            collection.singleStructureList.Add(facility);
            collection.zoneList = new List<ZoneStructureSO>();
            collection.zoneList.Add(zone);

            GameObject testObj = new GameObject();
            structureHolder = testObj.AddComponent<StructureHolder>();
            structureHolder.structureCollection = collection;
		}


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator StructureHolderTestsZoneListQuantityWithEnumeratorPasses()
        {
            int quanitity = structureHolder.GetZoneNames().Count;
            yield return new WaitForEndOfFrame();
            Assert.AreEqual(1, quanitity);
        }

        [UnityTest]
        public IEnumerator StructureHolderTestsZoneListNameWithEnumeratorPasses()
        {
            string name = structureHolder.GetZoneNames()[0];
            yield return new WaitForEndOfFrame();
            Assert.AreEqual("Commercial", name);
        }
    }
}
