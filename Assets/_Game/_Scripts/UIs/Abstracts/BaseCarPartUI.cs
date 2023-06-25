using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public abstract class BaseCarPartUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI partText;
        private string _partType;
        private CarController _carController;


        protected virtual void Awake()
        {
            partText = GetComponentInChildren<TextMeshProUGUI>();
        }

        private void Start()
        {
            _carController = GetComponentInParent<CarSettingsCanvas>().CarController;
        }

        public void SetPart<T>(T partType)
        {
            partText.text = partType.ToString();
        }
    }
}
