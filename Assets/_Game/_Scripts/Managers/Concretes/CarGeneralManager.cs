using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RedAxeCase
{
    public class CarGeneralManager : SingletonMonoBehaviour<CarGeneralManager>
    {
        public Dictionary<CarController, CarTabPanel> carDictionary;
        
        protected override void Awake()
        {
            base.Awake();
            carDictionary = new Dictionary<CarController, CarTabPanel>();
        }

        private void Update()
        {
            // KeyCodes 
            if (Input.GetKeyDown(KeyCode.B))
                CursorMode.SetCursorMode(true);

            if (Input.GetKeyUp(KeyCode.R))
                StartCoroutine(HandleReset());
        }
        
 
        private IEnumerator HandleReset()
        {            
            FindObjectOfType<FirstPersonController>().enabled = false;
            yield return new WaitForSeconds(2.0f);
            SceneManager.LoadScene(0);
        }
    }
}
