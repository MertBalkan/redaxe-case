using System.Collections;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class OfferInputField : MonoBehaviour
    {
        private TMP_InputField _offerInputField;

        private void Start()
        {
            _offerInputField = GetComponent<TMP_InputField>();
        }
    }
}
