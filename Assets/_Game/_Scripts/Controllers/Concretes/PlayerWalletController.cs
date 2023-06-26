using System;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerWalletController : MonoBehaviour
    {
        [SerializeField] private int moneyAmount;
        [SerializeField] private TextMeshProUGUI moneyText;
        private OfferPanel _offerPanel;
        
        public int MoneyAmount { get => moneyAmount; }
        public bool IsWalletEmpty => moneyAmount <= 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                moneyAmount += 100000;
            }

            moneyText.text = "Your money: " + moneyAmount;
        }

        public void DecreaseMoney(int decreaseAmount)
        {
            if (moneyAmount <= 0) moneyAmount = 0;
            moneyAmount -= decreaseAmount;
        }
    }
}