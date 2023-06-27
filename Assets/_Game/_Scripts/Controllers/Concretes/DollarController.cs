using System;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class DollarController : MonoBehaviour
    {
        private TextMeshProUGUI _costText;
        private CarController _carController;

        public TextMeshProUGUI CostText => _costText;
        
        private void Awake()
        {
            _costText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Update()
        {
            foreach (var keyValuePair in CarCostCalculatorManager.Instance.carCostDictionary)
                if(keyValuePair.Key == _carController)
                    _costText.text = keyValuePair.Value.ToString();
            
        }

        public void SetCostToUI(CarController carController)
        {
            _carController = carController;
            var cost = CarCostCalculatorManager.Instance.carCostDictionary[carController];
            
            _costText.text = (cost.ToString());
        }

        public void SetText(string text)
        {
            _costText.text = text;
        }

        public string FormatText(string text)
        {
            if (Int32.TryParse(text, out int number))
                return number.ToString("#,0");
            
            return text;
        }
    }
}
