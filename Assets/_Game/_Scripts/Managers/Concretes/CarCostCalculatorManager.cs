using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class CarCostCalculatorManager : SingletonMonoBehaviour<CarCostCalculatorManager>
    {
        public Dictionary<CarController, int> carValueDictionary;

        protected override void Awake()
        {
            base.Awake();
            carValueDictionary = new Dictionary<CarController, int>();
        }

        public void InitCarValues(CarController carController)
        {
            carValueDictionary.Add(carController, 1);
        }

        private void Update()
        {
            foreach (var keyValuePair in carValueDictionary)
            {
                Debug.LogWarning(keyValuePair.Key + "," + keyValuePair.Value);
                
            }
        }
    }
}
