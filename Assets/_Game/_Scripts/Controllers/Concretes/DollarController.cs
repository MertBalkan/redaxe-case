using System;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class DollarController : MonoBehaviour
    {
        private TextMeshProUGUI _costText;

        private void Awake()
        {
            _costText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetCostToUI(CarController carController)
        {
            var cost = CarCostCalculatorManager.Instance.carValueDictionary[carController];
            string formattedNumber = $"{cost:#,##0}";

            _costText.text = formattedNumber + "$";
        }
    }
}
