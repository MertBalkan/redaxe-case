using System;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerWalletController : MonoBehaviour
    {
        [SerializeField] private int moneyAmount;

        public int MoneyAmount { get => moneyAmount; set => moneyAmount = value; }
        public bool IsWalletEmpty => moneyAmount <= 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                moneyAmount += 100000;
            }
        }
    }
}