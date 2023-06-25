using System.Collections.Generic;

namespace RedAxeCase
{
    public class CarGeneralManager : SingletonMonoBehaviour<CarGeneralManager>
    {
        public Dictionary<CarController, CarTabPanel> carDictionary;
        
        protected override void Awake()
        {
            base.Awake();
            carDictionary = new Dictionary<CarController, CarTabPanel>();
        }
    }
}
