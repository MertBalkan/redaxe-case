using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedAxeCase
{
    public class CarController : MonoBehaviour, ICarController
    {
        [SerializeField] private List<Material> randomizedMaterials;
        [Header("=====Car Part Panels=====")]
        [SerializeField] private PropertyPartPanel partPanels;
        private RCC_CarControllerV3 _controller;
        
        private ICarRandomizePart _randomizedDamage;
        private ICarRandomizePart _randomizedProperty;
        private ICarRandomizePart _randomizedColor;
        
        public RCC_CarControllerV3 Controller => _controller;
        public List<ICarRandomizePart> randomizeParts;

        private void Awake()
        {
            _controller = GetComponent<RCC_CarControllerV3>();
            partPanels = FindObjectOfType<PropertyPartPanel>();
            
            _randomizedColor = new CarColorRandomizerSystem(this, randomizedMaterials);
            _randomizedProperty = new CarPropertyRandomizerSystem(this, partPanels);
            _randomizedDamage = new CarDamageRandomizerSystem(this, null);
        }

        private void Start() => SetRandomizeParts();

        private void SetRandomizeParts()
        {
            randomizeParts = new List<ICarRandomizePart>
            {
                _randomizedColor,
                _randomizedDamage,
                _randomizedProperty
            };   
        }
    }
}