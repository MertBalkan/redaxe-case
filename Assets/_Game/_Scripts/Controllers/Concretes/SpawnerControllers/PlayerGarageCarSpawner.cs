using System;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerGarageCarSpawner : MonoBehaviour
    {
        private void Start()
        {
            PlayerGarageManager.Instance.PlayerGarageCarSpawner = this;
        }
    }
}
