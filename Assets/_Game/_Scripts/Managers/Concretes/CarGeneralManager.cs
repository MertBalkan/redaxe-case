using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
