using UnityEngine;
using UnityEngine.Serialization;

namespace RedAxeCase
{
    public class CarTabPanel : MonoBehaviour
    {
        [SerializeField] private CarSettingsCanvas carSettingsCanvas;
        private void Start()
        {
            CarGeneralManager.Instance.carDictionary.Add(carSettingsCanvas.CarController, carSettingsCanvas.CarController.CarTabPanel);
            carSettingsCanvas.CarController.SetRandomizeParts();
            carSettingsCanvas.CarController.CarPartRandomizerLoader.InitRandomizers();
        }
    }
}