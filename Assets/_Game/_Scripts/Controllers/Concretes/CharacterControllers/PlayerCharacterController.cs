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
            _marketController.OnExitMarket    += HandleOnMarketExit;
            _marketController.OnGotoGarage    += HandleOnGotoMarket;
        }

        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket    -= HandleOnMarketExit;
            _marketController.OnGotoGarage    -= HandleOnGotoMarket;
        }
        private void HandleOnGotoMarket()
        {
            SelectMarketMode(false, true);
        }

        public void HandleOnMarketEntered()
        {
            SelectMarketMode(false, true);
        }

        public void HandleOnMarketExit()
        {
            SelectMarketMode(true, false);
        }

        private void SelectMarketMode(bool fpsCamMode, bool cursorMode)
        {
            fpsCam.gameObject.SetActive(fpsCamMode);
            _firstPersonController.enabled = fpsCamMode;
            CursorMode.SetCursorMode(cursorMode);
        }
    }
}
