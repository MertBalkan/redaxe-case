using System;
using UnityEngine;

namespace RedAxeCase
{
    public class MarketController : MonoBehaviour
    {
        [SerializeField] private CarSellerCanvas carSellerCanvas;
        public System.Action OnGotoGarage;
        public System.Action OnEnteredMarket;
        public System.Action OnExitMarket;
        
        private void OnTriggerEnter(Collider other)
        {
            carSellerCanvas.gameObject.SetActive(true);
            EnterMarket(other);
        }

        public void EnterMarket(Collider other)
        {
            var player = other.GetComponent<PlayerCharacterController>();
            
            if (player != null)
                OnEnteredMarket?.Invoke();
        }

        public void GotoGarage()
        {
            OnGotoGarage?.Invoke();
        }
        
        public void ExitMarket()
        {
            OnExitMarket?.Invoke();            
        }
    }
}
