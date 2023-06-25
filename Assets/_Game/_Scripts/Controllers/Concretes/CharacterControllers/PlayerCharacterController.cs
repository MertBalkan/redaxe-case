using StarterAssets;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private Transform fpsCam;
        private MarketController _marketController;
        private FirstPersonController _firstPersonController;

        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
            _firstPersonController = GetComponent<FirstPersonController>();
        }

        private void Start()
        {
            _marketController.OnEnteredMarket += HandleOnMarketEntered;
            _marketController.OnExitMarket += HandleOnMarketExit;
        }

        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket -= HandleOnMarketExit;
        }
        
        public void HandleOnMarketEntered()
        {
            fpsCam.gameObject.SetActive(false);
            _firstPersonController.enabled = false;
            CursorMode.SetCursorMode(true);
        }

        public void HandleOnMarketExit()
        {
            fpsCam.gameObject.SetActive(true);
            _firstPersonController.enabled = true;
            CursorMode.SetCursorMode(false);
        }
    }
}
