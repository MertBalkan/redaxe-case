using System.Collections;
using StarterAssets;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerCharacterController : BaseCharacterController
    {
        [SerializeField] private PlayerFollowCameraController fpsCam;
        private MarketController _marketController;
        private FirstPersonController _firstPersonController;

        public FirstPersonController FirstPersonController => _firstPersonController;

        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
            _firstPersonController = GetComponent<FirstPersonController>();
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(StartDelayTimeConst.MarketEventSubscribeDelayTime);
            
            
            _marketController.OnEnteredMarket += HandleOnMarketEntered;
            _marketController.OnExitMarket    += HandleOnMarketExit;
            _marketController.OnGotoGarage    += HandleOnGotoGarage;
        }

        private void OnDisable()
        {
            _marketController.OnEnteredMarket -= HandleOnMarketEntered;
            _marketController.OnExitMarket    -= HandleOnMarketExit;
            _marketController.OnGotoGarage    -= HandleOnGotoGarage;
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

        private void SetModes(bool fpsCamMode, bool cursorMode)
        {
            fpsCam.gameObject.SetActive(fpsCamMode);
            _firstPersonController.enabled = fpsCamMode;
            CursorMode.SetCursorMode(cursorMode);
        }
    }
}
