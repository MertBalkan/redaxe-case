using System;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class OfferInputField : MonoBehaviour
    {
        private TMP_InputField _offerInputField;
        private int _offerValue;

        public TMP_InputField OfferInputTMP => _offerInputField;
        public int OfferValue => _offerValue;
        private void Start()
        {
            _offerInputField = GetComponent<TMP_InputField>();
        }

        public void FocusEnd()
        { 
            _offerValue = Int32.Parse(_offerInputField.text);
        }
    }
}
