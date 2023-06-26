using UnityEngine;

namespace RedAxeCase
{
    public class CarSettingsCanvas : MonoBehaviour
    {
        [SerializeField] private CarController carController;
        [SerializeField] private BargainSystem bargainSystem;
        public CarController CarController { get => carController; set => carController = value; }
        public BargainSystem BargainSystem { get => bargainSystem; set => bargainSystem = value; }
    }
}
