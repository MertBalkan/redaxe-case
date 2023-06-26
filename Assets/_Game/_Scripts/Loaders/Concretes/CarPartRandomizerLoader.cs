using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RedAxeCase
{
    public class CarPartRandomizerLoader : MonoBehaviour
    {
        [SerializeField] private CarController carController;
        private List<Action<CarTabPanel>> _loader;

        private void Awake()
        {
            _loader = new List<Action<CarTabPanel>>();
        }


        public void InitRandomizers()
        {
            AddRandomizers();
            StartRandomizer();
        }

        private void StartRandomizer()
        {
            var carPanel = CarGeneralManager.Instance.carDictionary[carController]; 
            
            if(carPanel != null)
                LoadRandomizers(_loader, carPanel);                
        }

        private void AddRandomizers()
        {
            foreach (var randomPart in carController.RandomizeParts)
                _loader.Add(randomPart.Randomize);
        }

        private void LoadRandomizers(List<Action<CarTabPanel>> randomizeActions, CarTabPanel tabPanel)
        {
            foreach (var randomizeAction in randomizeActions)
                randomizeAction.Invoke(tabPanel);
        }
    }
}