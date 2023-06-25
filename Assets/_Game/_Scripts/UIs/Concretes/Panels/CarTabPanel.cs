using UnityEngine;

namespace RedAxeCase
{
    public class CarTabPanel : MonoBehaviour
    {
        [SerializeField] private CarSettingsCanvas _carSettingsCanvas;
        private void Start()
        {
            CarGeneralManager.Instance.carDictionary.Add(_carSettingsCanvas.CarController, _carSettingsCanvas.CarController.CarTabPanel);
            _carSettingsCanvas.CarController.SetRandomizeParts();
            _carSettingsCanvas.CarController.CarPartRandomizerLoader.InitRandomizers();
        }
    }
}