using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarDamageRandomizerSystem : ICarRandomizePart
    {
        private Rigidbody[] _damagableParts;
        private ICarController _carController;

        
        public CarDamageRandomizerSystem(ICarController carController, Rigidbody[] damagableParts)
        {
            _damagableParts = damagableParts;
            _carController = carController;
        }

        public void Randomize()
        {
            
        }
    }
}
