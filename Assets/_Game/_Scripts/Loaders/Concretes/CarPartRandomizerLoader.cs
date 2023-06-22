using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedAxeCase
{
    public class CarPartRandomizerLoader : MonoBehaviour
    {
        private CarController _carController;
        private List<Action> _loader;

        private void Start()
        {
            _carController = GetComponent<CarController>();
            _loader = new List<Action>();
            
            AddRandomizers();
        }

        public void StartRandomizer()
        {
            LoadRandomizers(_loader);                
        }

        private void AddRandomizers()
        {
            foreach (var randomPart in _carController.randomizeParts)
                _loader.Add(randomPart.Randomize);
        }

        private void LoadRandomizers(List<Action> randomizeActions)
        {
            foreach (var randomizeAction in randomizeActions)
                randomizeAction.Invoke();
        }
    }
}