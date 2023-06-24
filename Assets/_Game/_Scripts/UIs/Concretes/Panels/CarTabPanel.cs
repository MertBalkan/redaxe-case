using UnityEngine;

namespace RedAxeCase
{
    public class CarTabPanel : MonoBehaviour
    {
        [SerializeField] private CarSettingsCanvas _carSettingsCanvas;
        public int id;

        private void Start()
        {
            // _carSettingsCanvas.CarController.CarTabPanel = this;
            CarGeneralManager.Instance.carDictionary.Add(_carSettingsCanvas.CarController, _carSettingsCanvas.CarController.CarTabPanel);
            _carSettingsCanvas.CarController.SetRandomizeParts();
            _carSettingsCanvas.CarController.CarPartRandomizerLoader.InitRandomizers();
        }
    }
}