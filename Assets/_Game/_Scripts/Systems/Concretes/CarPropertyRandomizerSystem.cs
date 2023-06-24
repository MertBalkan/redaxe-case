using UnityEngine;

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
            _carSpeed = Random.Range(200, 280);
            _engineTorque = Random.Range(350, 480);
            _suspensionsDistance = Random.Range(0.1f, 0.2f);
            
            _carController.Controller.maxspeed = _carSpeed;
            _carController.Controller.maxEngineTorque = _engineTorque;

            foreach (var wheelCollider in _carController.Controller.AllWheelColliders)
            {
                wheelCollider.WheelCollider.suspensionDistance = _suspensionsDistance;
            }
            
            var propertyPartPanel = tabPanel.GetComponentInChildren<PropertyTabPanel>();
            CarCostCalculatorManager.Instance.carValueDictionary[_carController] *= (int)_carSpeed;
            CarCostCalculatorManager.Instance.carValueDictionary[_carController] *= (int)_engineTorque;
            CarCostCalculatorManager.Instance.carValueDictionary[_carController] += ((int)Mathf.Floor(_suspensionsDistance) * 100);
            
            propertyPartPanel.AddNewPart("Engine Torque: " + _engineTorque, null); 
            propertyPartPanel.AddNewPart("Car Speed: " + _carSpeed, null);
            propertyPartPanel.AddNewPart("Suspension Distance: " + _suspensionsDistance, null);
        }
    }
}