using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RedAxeCase
{
    public class CarCostCalculatorManager : SingletonMonoBehaviour<CarCostCalculatorManager>
    {
        public Dictionary<CarController, int> carCostDictionary;
        public HashSet<int> initialCarCosts;

        protected override void Awake()
        {
            base.Awake();
            carCostDictionary = new Dictionary<CarController, int>();
            initialCarCosts = new HashSet<int>();
        }

        public void InitCarValues(CarController carController)
        {
            carCostDictionary.Add(carController, 1);
        }
    }
}