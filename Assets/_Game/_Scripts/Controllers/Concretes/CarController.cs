using System;
using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarController : MonoBehaviour, ICarController
    {
        [SerializeField] private List<Material> randomizedMaterials;
        private RCC_CarControllerV3 _controller;
        
        private ICarRandomizePart _randomizedDamage;
        private ICarRandomizePart _randomizedProperty;
        private ICarRandomizePart _randomizedColor;
        
        public RCC_CarControllerV3 Controller => _controller;
        public List<ICarRandomizePart> randomizeParts;

        private void Awake()
        {
            _controller = GetComponent<RCC_CarControllerV3>();
            
            _randomizedColor = new CarColorRandomizerSystem(this, randomizedMaterials);
            _randomizedProperty = new CarPropertyRandomizerSystem(this);
            _randomizedDamage = new CarDamageRandomizerSystem(this, null);
        }
        

        private void Start()
        {
            randomizeParts = new List<ICarRandomizePart>();

            randomizeParts.Add(_randomizedColor);
            // randomizeParts.Add(_randomizedDamage);
            randomizeParts.Add(_randomizedProperty);
        }
    }
}