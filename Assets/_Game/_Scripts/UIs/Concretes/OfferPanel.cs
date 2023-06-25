using StarterAssets;
using UnityEngine;

namespace RedAxeCase
{
    public class OfferPanel : MonoBehaviour
    {
        private OfferInputField _offerInputField;
        private CarSettingsCanvas _carSettingsCanvas;
        private PlayerWalletController _playerWalletController;
        private PlayerFollowCameraController _followCameraController;

        public System.Action OnCarSold;
        
        private void Start()
        {
            _carSettingsCanvas = GetComponentInParent<CarSettingsCanvas>();
            _offerInputField = GetComponentInChildren<OfferInputField>();
            _playerWalletController = FindObjectOfType<PlayerWalletController>();
            _followCameraController = FindObjectOfType<PlayerFollowCameraController>();
        }

        public void BuyButton()
        {
            if (_playerWalletController.IsWalletEmpty) return;
            
            int carAmount = CarCostCalculatorManager.Instance.carCostDictionary[_carSettingsCanvas.CarController];

            if (_playerWalletController.MoneyAmount >= carAmount)
            {
                _playerWalletController.MoneyAmount -= carAmount;
                
                OnCarSold?.Invoke();
                
                FindObjectOfType<GarageCameraController>().gameObject.SetActive(false);
                _followCameraController.gameObject.SetActive(true);
                _playerWalletController.gameObject.GetComponent<FirstPersonController>().enabled = true;
                Debug.Log(_carSettingsCanvas.CarController.name + " sold");
            }
        }
    }
}
