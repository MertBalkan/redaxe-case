using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedAxeCase
{
    public class CarDamageRandomizerSystem : ICarRandomizePart
    {
        private CarController _carController;
        
        // I dont have time to left manage this code properly so i did just
        // take them with a string values.
        private Dictionary<string, int> carDamagePartsDictionary = new Dictionary<string, int>
        {
            {"Tires", 4},
            {"Hood", 6},
            {"Left Door", 5},
            {"Right Door", 5},
            {"Trunk", 4},
            {"Front Bumper", 10},
            {"Body", 10}
        };
        
        
        public CarDamageRandomizerSystem(CarController carController)
        {
            _carController = carController;
        }

        public void Randomize(CarTabPanel tabPanel)
        {
            SetCarDamages(tabPanel);
        }
        
        private void SetCarDamages(CarTabPanel tabPanel)
        {
            Debug.Log(tabPanel.name);
            
            var damagePartPanel = tabPanel.GetComponentInChildren<DamageTabPanel>();
            var randomIndex = Random.Range(0, carDamagePartsDictionary.Count);
            var pairs = new KeyValuePair<string, int>[randomIndex];

            if(pairs.Length == 0) damagePartPanel.AddNewPart("Car has no damage"); 

            for (int i = 0; i < randomIndex; i++)
                pairs[i] = GetRandomElement();

            foreach (var keyValuePair in pairs)
            {
                var keyValue = keyValuePair.Value * 4;
                damagePartPanel.AddNewPart(keyValuePair.Key);
            }
        }
        
        private KeyValuePair<string, int> GetRandomElement()
        {
            int randomIndex = Random.Range(0, carDamagePartsDictionary.Count);
            KeyValuePair<string, int> randomElement = carDamagePartsDictionary.ElementAt(randomIndex);
            return randomElement;
        }
    }
}
