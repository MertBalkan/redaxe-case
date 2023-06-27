using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class BargainSystem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI offerStatus;
        [SerializeField] private CarSettingsCanvas carSettingsCanvas;
        private bool isBargainingActive = true;

        public void MakeOffer()
        {
            var dollarController = carSettingsCanvas.GetComponentInChildren<DollarController>();
            int initialPrice = Int32.Parse(dollarController.CostText.text);
            int minPrice = initialPrice - 10000;
            int maxPrice = initialPrice + 10000;
            int bargainStep = 100;

            int randomOfferAmount = Random.Range(minPrice, maxPrice);
            
            int currentPrice = initialPrice;
            
            if (OfferStatus())
                return;

            Debug.Log("randomOfferAmount = " + randomOfferAmount);
            Debug.Log("initialPrice = " + initialPrice);
            
            if (randomOfferAmount > currentPrice)
            {
                Debug.Log("Offer accepted! Item sold for $" + currentPrice);
                offerStatus.text = "Offer accepted!";

                dollarController.SetText(randomOfferAmount.ToString());  
                isBargainingActive = false;
            }
            
            else if (randomOfferAmount < currentPrice && randomOfferAmount >= minPrice)
            {
                currentPrice -= bargainStep;
                Debug.Log("Counter-offer: $" + currentPrice);
            }
            
            else
            {
                offerStatus.text = "Offer rejected!";
            }
        }

        private bool OfferStatus() => !isBargainingActive;
    }
}