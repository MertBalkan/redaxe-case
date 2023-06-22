using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedAxeCase
{
    public class CarPartRandomizerLoader : MonoBehaviour
    {
        private CarController _carController;
        private List<Action<BasePartPanel>> _loader;

        private void Start()
        {
            _carController = GetComponent<CarController>();
            _loader = new List<Action<BasePartPanel>>();
            
            AddRandomizers();
        }

        public void StartRandomizer()
        {
            LoadRandomizers(_loader, FindObjectOfType<PropertyPartPanel>());                
        }

        private void AddRandomizers()
        {
            try
            {
                foreach (var randomPart in _carController.randomizeParts)
                    _loader.Add(randomPart.Randomize);
            }
            catch (Exception e)
            {
                Debug.LogWarning(e.Message);
            }
        }

        private void LoadRandomizers(List<Action<BasePartPanel>> randomizeActions, BasePartPanel basePartPanel)
        {
            foreach (var randomizeAction in randomizeActions)
                randomizeAction.Invoke(basePartPanel);
        }
    }
}