using UnityEngine;

namespace RedAxeCase
{
    public class CarDamageRandomizerSystem : ICarRandomizePart
    {
        private ICarController _carController;
        
        
        public CarDamageRandomizerSystem(ICarController carController)
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
        }
    }
}
