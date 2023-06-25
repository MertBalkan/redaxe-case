using UnityEngine;
using System.Linq;

namespace RedAxeCase
{
    public class CarPropertyRandomizerSystem : ICarRandomizePart
    {
        private CarController _carController;
        
        private float _carSpeed;
        private float _engineTorque;
        private float _suspensionsDistance;

        public CarPropertyRandomizerSystem(CarController carController)
        {
            _carController = carController;
        }
        
        public void Randomize(CarTabPanel tabPanel)
        {
            SetCarProperties(tabPanel);
        }

        private void SetCarProperties(CarTabPanel tabPanel)
        {
            _carSpeed = GenerateRandomProperty(200, 280);
            _engineTorque = GenerateRandomProperty(350, 480);
            _suspensionsDistance = GenerateRandomProperty(0.1f, 0.2f);
            
            _carController.Controller.maxspeed = _carSpeed;
            _carController.Controller.maxEngineTorque = _engineTorque;

            _carController.Controller.AllWheelColliders.
                ToList().
                ForEach(w => w.WheelCollider.suspensionDistance = _suspensionsDistance);
            
            var propertyPartPanel = tabPanel.GetComponentInChildren<PropertyTabPanel>();
            
            CarCostCalculatorManager.Instance.carCostDictionary[_carController] *= (int)_carSpeed;
            CarCostCalculatorManager.Instance.carCostDictionary[_carController] *= (int)_engineTorque;
            CarCostCalculatorManager.Instance.carCostDictionary[_carController] += ((int)Mathf.Floor(_suspensionsDistance) * 100);
            
                
            propertyPartPanel.AddNewPart("Engine Torque: " + _engineTorque); 
            propertyPartPanel.AddNewPart("Car Speed: " + _carSpeed);
            propertyPartPanel.AddNewPart("Suspension Distance: " + _suspensionsDistance);
        }
        
        private float GenerateRandomProperty (float min, float max) => Random.Range(min, max);
        private int GenerateRandomProperty (int min, int max) => Random.Range(min, max);
    }
}