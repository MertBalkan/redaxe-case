using System;
using System.Collections.Generic;
using System.Linq;
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
            if(CarGeneralManager.Instance.carDictionary[_carController] != null)
                LoadRandomizers(_loader, CarGeneralManager.Instance.carDictionary[_carController]);                
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