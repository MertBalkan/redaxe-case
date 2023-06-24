using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Serialization;

namespace RedAxeCase
{
    public class CarController : MonoBehaviour, ICarController
    {
        [SerializeField] private Dictionary<ICarController, Material> randomizedMaterials;
        [SerializeField] private CarTabPanel carTabPanel;
        
        private ICarRandomizePart _randomizedDamage;
        private ICarRandomizePart _randomizedProperty;
        private ICarRandomizePart _randomizedColor;
        private List<ICarRandomizePart> _randomizeParts;
        private CarController _carController;
        
        private RCC_CarControllerV3 _controller;
        private CarPartRandomizerLoader _carPartRandomizerLoader;

        public RCC_CarControllerV3 Controller => _controller;
        public List<ICarRandomizePart> RandomizeParts { get => _randomizeParts; set => _randomizeParts = value; }
        public CarPartRandomizerLoader CarPartRandomizerLoader => _carPartRandomizerLoader;
        public CarTabPanel CarTabPanel
        {
            get
            {
                return carTabPanel;
            }
            set
            {
                carTabPanel = value;
            }
        }

        private void Awake()
        {
            _controller = GetComponent<RCC_CarControllerV3>();
            _carPartRandomizerLoader = GetComponent<CarPartRandomizerLoader>();
            randomizedMaterials = new Dictionary<ICarController, Material>();
            _carController = this;

        }

        private void OnEnable()
        {
        }

        private void Start()
        {
            CarCostCalculatorManager.Instance.InitCarValues(_carController);
        }
        
        public void SetRandomizeParts()
        {
            _randomizedColor = new CarColorRandomizerSystem(this, randomizedMaterials);
            _randomizedProperty = new CarPropertyRandomizerSystem(this);
            _randomizedDamage = new CarDamageRandomizerSystem(this, null);

            _randomizeParts = new List<ICarRandomizePart>
            {
                _randomizedColor,
                _randomizedDamage,
                _randomizedProperty
            };   
        }
    }
}