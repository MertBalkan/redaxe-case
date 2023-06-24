using UnityEngine;

namespace RedAxeCase
{
    public class MarketController : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            var player = other.GetComponent<PlayerCharacterController>();
            if (player != null)
            {
                
            }
        }
    }
}
