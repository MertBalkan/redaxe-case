using UnityEngine;

namespace RedAxeCase
{
    public class SellerController : MonoBehaviour
    {
        [SerializeField] private Transform sellerCam;
        private MarketController _marketController;    


        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
        }

        private void Start()
        {
            _marketController.OnEnteredMarket += HandleOnMarketEntered;
            _marketController.OnExitMarket    += HandleOnExitMarket;
        }
        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket    -= HandleOnExitMarket;
        }

        private void HandleOnMarketEntered()
        {
            SetModes(true, false);
        }

        private void HandleOnExitMarket()
        {
            SetModes(false, true);
        }
        
        private void HandleOnCarSold()
        {
            SetModes(false, true);
        }

        private void SetModes(bool sellerMode, bool cursorMode)
        {
            sellerCam.gameObject.SetActive(sellerMode);
            CursorMode.SetCursorMode(cursorMode);
        }
    }
}