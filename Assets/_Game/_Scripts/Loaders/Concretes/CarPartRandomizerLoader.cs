using System;
using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarPartRandomizerLoader : MonoBehaviour
    {
        private CarController _carController;
        private List<Action<CarTabPanel>> _loader;

        private void Awake()
        {
            _carController = GetComponent<CarController>();
            _loader = new List<Action<CarTabPanel>>();
        }

        public void InitRandomizers()
        {
            AddRandomizers();
            StartRandomizer();
        }

        private void StartRandomizer()
        {
            var carPanel = CarGeneralManager.Instance.carDictionary[_carController]; 
            
            if(carPanel != null)
                LoadRandomizers(_loader, carPanel);                
        }

        private void AddRandomizers()
        {
            foreach (var randomPart in _carController.RandomizeParts)
                _loader.Add(randomPart.Randomize);
        }

        private void LoadRandomizers(List<Action<CarTabPanel>> randomizeActions, CarTabPanel tabPanel)
        {
            foreach (var randomizeAction in randomizeActions)
                randomizeAction.Invoke(tabPanel);
        }
    }
}