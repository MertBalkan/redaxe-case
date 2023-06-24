using UnityEngine;

namespace RedAxeCase
{
    public class CarSettingsCanvas : MonoBehaviour
    {
        [SerializeField] private CarController carController;
        public CarController CarController { get => carController; set => carController = value; }
    }
}
