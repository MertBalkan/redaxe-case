using UnityEngine;

namespace RedAxeCase
{
    public class CarPropertyRandomizerSystem : ICarRandomizePart
    {
        private ICarController _carController;
        
        private float _carSpeed;
        private float _engineTorque;

        public CarPropertyRandomizerSystem(ICarController carController)
        {
            _carController = carController;
        }
        
        public void Randomize(CarTabPanel tabPanel)
        {

            Debug.Log(_carController.Controller.gameObject.name + " CALLED " + " tabPanel" + tabPanel);
            
            SetCarProperties(tabPanel);
        
        }

        private void SetCarProperties(CarTabPanel tabPanel)
        {         
            _carSpeed = Random.Range(200, 280);
            _engineTorque = Random.Range(350, 480);

            _carController.Controller.maxspeed = _carSpeed;
            _carController.Controller.maxEngineTorque = _engineTorque;

            var propertyPartPanel = tabPanel.GetComponentInChildren<PropertyTabPanel>();

            Debug.Log( _carController.ToString() + " _carController.Controller.maxEngineTorque = " + _carController.Controller.maxEngineTorque);
            
            propertyPartPanel.AddNewPart("Engine Torque: " + _engineTorque, null);
            propertyPartPanel.AddNewPart("Car Speed: " + _carSpeed, null);
        }
    }
}