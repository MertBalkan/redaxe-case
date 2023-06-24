using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RedAxeCase
{
    public class PropertyTabPanel : BaseTabPanel, ITabPanel
    {
        [SerializeField] private PropertyPartUI partUI;
        private Vector3 _originalSize;

        public void AddNewPart<T>(T partName, Image partImage)
        {
            var propertyTabUI = Instantiate(partUI, transform.position, transform.rotation, transform);
            _originalSize = propertyTabUI.transform.localScale;
            propertyTabUI.transform.localScale = _originalSize;
            partUI.SetPart(partName, partImage);
        }
    }
}