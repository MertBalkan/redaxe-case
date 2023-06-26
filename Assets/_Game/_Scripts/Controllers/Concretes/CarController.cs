using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarController : MonoBehaviour, ICarController
    {
        [SerializeField] private CarTabPanel carTabPanel;
        [SerializeField] private RCC_Camera rccCamera;
        
        private ICarRandomizePart _randomizedDamage;
        private ICarRandomizePart _randomizedProperty;
        private ICarRandomizePart _randomizedColor;
        
        private List<ICarRandomizePart> _randomizeParts;
        private Dictionary<ICarController, Material> _randomizedMaterials;
        
        private CarController _carController;
        private RCC_CarControllerV3 _controller;
        private CarPartRandomizerLoader _carPartRandomizerLoader;

        public RCC_CarControllerV3 Controller => _controller;
        public List<ICarRandomizePart> RandomizeParts { get => _randomizeParts; set => _randomizeParts = value; }
        public CarPartRandomizerLoader CarPartRandomizerLoader => _carPartRandomizerLoader;
        public CarTabPanel CarTabPanel { get  => carTabPanel; set  => carTabPanel = value; }

        private void Awake()
        {
            _controller = GetComponent<RCC_CarControllerV3>();
            _carPartRandomizerLoader = GetComponent<CarPartRandomizerLoader>();
            _randomizedMaterials = new Dictionary<ICarController, Material>();
            _carController = this;
        }


        private void Start()
        {
            CarCostCalculatorManager.Instance.InitCarValues(_carController);
        }
        
        private void OnTriggerStay(Collider other)
        {
       
            var player = other.GetComponent<PlayerCharacterController>();

            if (player != null && Input.GetKeyDown(KeyCode.E))
                EnterCar(player);
        }

        private void EnterCar(PlayerCharacterController player)
        {
            player.FirstPersonController.enabled = false;
            _controller.enabled = true;
            rccCamera.gameObject.SetActive(true);
        }

        
        public void SetRandomizeParts()
        {
            _randomizedColor = new CarColorRandomizerSystem(this, _randomizedMaterials);
            _randomizedProperty = new CarPropertyRandomizerSystem(this);
            _randomizedDamage = new CarDamageRandomizerSystem(this);

            _randomizeParts = new List<ICarRandomizePart>
            {
                _randomizedColor,
                _randomizedDamage,
                _randomizedProperty
            };   
        }
    }
}