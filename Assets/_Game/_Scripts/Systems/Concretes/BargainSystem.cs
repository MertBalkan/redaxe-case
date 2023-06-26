using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class BargainSystem : MonoBehaviour
    {
        public System.Action<CarSettingsCanvas> OnNewBargainOffered;

        private bool isBargainingActive = true;

        private void Start()
        {
            OnNewBargainOffered += MakeOffer;
        }

        private void OnDisable()
        {
            OnNewBargainOffered -= MakeOffer;
        }

        public void MakeOffer(CarSettingsCanvas carSettingsCanvas)
        {
            int initialPrice = Int32.Parse(carSettingsCanvas.GetComponentInChildren<OfferInputField>().OfferInputTMP.text);
            int minPrice = initialPrice - 10000;
            int maxPrice = initialPrice + 10000;
            int bargainStep = 100;

            int randomOfferAmount = Random.Range(minPrice, maxPrice);
            
            int currentPrice = initialPrice;
            
            if (OfferStatus())
                return;

            Debug.Log("randomOfferAmount = " + randomOfferAmount);
            Debug.Log("initialPrice = " + initialPrice);
            
            if (randomOfferAmount < currentPrice)
            {
                Debug.Log("Offer accepted! Item sold for $" + currentPrice);
                var dollarController = carSettingsCanvas.GetComponentInChildren<DollarController>();
                dollarController.CostText.text = dollarController.FormatText(randomOfferAmount.ToString());  
                isBargainingActive = false;
            }
            
            else if (randomOfferAmount < currentPrice && randomOfferAmount >= minPrice)
            {
                currentPrice -= bargainStep;
                Debug.Log("Counter-offer: $" + currentPrice);
            }
            
            else
            {
                Debug.Log("Offer rejected!");
            }
        }

        private bool OfferStatus() => !isBargainingActive;
    }
}