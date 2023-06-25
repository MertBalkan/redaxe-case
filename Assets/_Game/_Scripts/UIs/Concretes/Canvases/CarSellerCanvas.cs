using System;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public class CarSellerCanvas : MonoBehaviour
    {
        [SerializeField] private Button goGarageButton;
        [SerializeField] private Button leaveButton;
        private MarketController _marketController;

        private void Awake()
        {
            _marketController = FindObjectOfType<MarketController>();
        }

        public void LeaveSeller()
        {
            _marketController.ExitMarket();
        }
    }
}
