using UnityEngine;

namespace RedAxeCase
{
    public class CarSellerCanvas : MonoBehaviour
    {
        private MarketController _marketController;

        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
        }

        public void GotoGarage()
        {
            _marketController.GotoGarage();
        }
        
        public void LeaveSeller()
        {
            _marketController.ExitMarket();
        }
    }
}
