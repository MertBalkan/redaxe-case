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
        private GarageCanvas _garageCanvas;

        public System.Action OnCarSold;
        
        private void Start()
        {
            // TODO: Change this spagetti code.
            _carSettingsCanvas = GetComponentInParent<CarSettingsCanvas>();
            _offerInputField = GetComponentInChildren<OfferInputField>();
            _playerWalletController = FindObjectOfType<PlayerWalletController>();
            _followCameraController = FindObjectOfType<PlayerFollowCameraController>();
        }

        public void BuyButton()
        {
            if (_playerWalletController.IsWalletEmpty) return;
            
            int carAmount = CarCostCalculatorManager.Instance.carCostDictionary[_carSettingsCanvas.CarController];

            if (_playerWalletController.MoneyAmount < carAmount) return;
            
            // Car has been sold successfully.
            
            _playerWalletController.DecreaseMoney(carAmount);
            OnCarSold?.Invoke();
            
            // TODO: Change this spagetti code.
                

            SetCameraAndController();
            Debug.Log(_carSettingsCanvas.CarController.name + " sold");
            
            _garageCanvas = FindObjectOfType<GarageCanvas>();
            _garageCanvas.gameObject.SetActive(false);
        
            //changing pos
            _carSettingsCanvas.CarController.transform.position = PlayerGarageManager.Instance.PlayerGarageCarSpawner.transform.position;
        }
        
        private void SetCameraAndController()
        {
            var garageCameraController = FindObjectOfType<GarageCameraController>();
            var playerController = _playerWalletController.gameObject.GetComponent<FirstPersonController>();

            garageCameraController.gameObject.SetActive(false);
            _followCameraController.gameObject.SetActive(true);
            playerController.enabled = true;
        }
    }
}
