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
            sellerCam.gameObject.SetActive(true);
            CursorMode.SetCursorMode(false);
        }

        private void HandleOnExitMarket()
        {
            sellerCam.gameObject.SetActive(false);
            CursorMode.SetCursorMode(true);
        }
    }
}