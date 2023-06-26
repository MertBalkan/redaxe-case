using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public abstract class BaseCarPartUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI partText;
        private string _partType;

        protected virtual void Awake()
        {
            partText = GetComponentInChildren<TextMeshProUGUI>();
        }

        public void SetPart<T>(T partType)
        {
            partText.text = partType.ToString();
        }
    }
}
