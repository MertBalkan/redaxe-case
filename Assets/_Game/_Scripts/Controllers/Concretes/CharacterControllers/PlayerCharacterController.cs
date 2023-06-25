using System.Collections;
using StarterAssets;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private Transform fpsCam;
        private MarketController _marketController;
        private FirstPersonController _firstPersonController;
        private OfferPanel _offerPanel;

        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
            _firstPersonController = GetComponent<FirstPersonController>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.2f * Time.deltaTime);
            _offerPanel = FindObjectOfType<OfferPanel>();
            
            Debug.Log("_offerPanel = " + _offerPanel);
            
            _marketController.OnEnteredMarket += HandleOnMarketEntered;
            _marketController.OnExitMarket    += HandleOnMarketExit;
            _marketController.OnGotoGarage    += HandleOnGotoGarage;
            _offerPanel.OnCarSold             += HandleOnCarSold;
        }

        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket    -= HandleOnMarketExit;
            _marketController.OnGotoGarage    -= HandleOnGotoGarage;
            _offerPanel.OnCarSold             -= HandleOnCarSold;
        }
        private void HandleOnGotoGarage()
        {
            SetModes(false, true);
        }

        public void HandleOnMarketEntered()
        {
            SetModes(false, true);
        }

        public void HandleOnMarketExit()
        {
            SetModes(true, false);
        }
        
        private void HandleOnCarSold()
        {
            SetModes(true, false);
        }

        private void SetModes(bool fpsCamMode, bool cursorMode)
        {
            fpsCam.gameObject.SetActive(fpsCamMode);
            _firstPersonController.enabled = fpsCamMode;
            CursorMode.SetCursorMode(cursorMode);
        }
    }
}
