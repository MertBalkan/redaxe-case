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
            _marketController.OnExitMarket += HandleOnExitMarket;
        }

        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket -= HandleOnExitMarket;
        }

        private void HandleOnMarketEntered()
        {
            SelectMarketMode(true, false);
        }

        private void HandleOnExitMarket()
        {
            SelectMarketMode(false, true);
        }
        
        private void SelectMarketMode(bool sellerMode, bool cursorMode)
        {
            sellerCam.gameObject.SetActive(sellerMode);
            CursorMode.SetCursorMode(cursorMode);
        }
    }
}