using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public abstract class BaseCarPartUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI partText;
        [SerializeField] private Image partImage;

        protected virtual void Awake()
        {
            partText = GetComponentInChildren<TextMeshProUGUI>();
            partImage = GetComponentInChildren<Image>();
        }

        public void SetPart<T>(T partType, Image img)
        {
            partText.text = partType.ToString();
            partImage = img;
        }
    }
}
