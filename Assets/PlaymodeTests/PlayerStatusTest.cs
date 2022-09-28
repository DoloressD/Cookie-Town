using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    [TestFixture]

    public class PlayerStatusTest
    {
        UIController uIController;
        GameManager gameManager;
        [SetUp]
        public void Init()

		{
            GameObject gameManagerObject = new GameObject();
            var cameraMovement = gameManagerObject.AddComponent<CameraMovement>();

            //gameManagerObject.AddComponent<InputManager>();
            uIController = gameManagerObject.AddComponent<UIController>();

            GameObject buildButtonObject = new GameObject();
            GameObject cancelButtonObject = new GameObject();
            GameObject cancelPanel = new GameObject();

            uIController.cancelActionBtn = cancelButtonObject.AddComponent<Button>();

            var buildButtonComponent = buildButtonObject.AddComponent<Button>();
            uIController.buildResidentialAreaBtn = buildButtonComponent;
            uIController.cancelActionPanel = cancelButtonObject;

            uIController.buildingModePanel = cancelPanel;
            uIController.openBuildMenuBtn = uIController.cancelActionBtn;
            uIController.demolishBtn = uIController.cancelActionBtn;

            gameManager = gameManagerObject.AddComponent<GameManager>();
            gameManager.cameraMovement = cameraMovement;
            gameManager.uiController = uIController;
		}
        // A Test behaves as an ordinary method
        
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator PlayerStatusPlayerBuildingSingleStructureStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //awake

            yield return new WaitForEndOfFrame(); //start

            uIController.buildResidentialAreaBtn.onClick.Invoke();

            yield return new WaitForEndOfFrame();

            Assert.IsTrue(gameManager.State is PlayerBuildingSingleStructureState);
        }

        [UnityTest]
        public IEnumerator PlayerStatusPlayerSelectionStateTestWithEnumeratorPasses()
        {
            yield return new WaitForEndOfFrame(); //awake

            yield return new WaitForEndOfFrame(); //start

            Assert.IsTrue(gameManager.State is PlayerSelectionState);
        }
    }
}
