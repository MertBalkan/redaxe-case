using UnityEngine;

namespace RedAxeCase
{
    public class MarketController : MonoBehaviour
    {
        public System.Action OnEnteredMarket;
        public System.Action OnExitMarket;
        
        private void OnTriggerEnter(Collider other)
        {
            EnterMarket(other);
        }

        public void EnterMarket(Collider other)
        {
            var player = other.GetComponent<PlayerCharacterController>();
            
            if (player != null)
                OnEnteredMarket?.Invoke();
        }
        
        public void ExitMarket()
        {
            OnExitMarket?.Invoke();            
        }
    }
}
