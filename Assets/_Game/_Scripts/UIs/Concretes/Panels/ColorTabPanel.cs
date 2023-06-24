using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace RedAxeCase
{
    public class ColorTabPanel : BaseTabPanel, ITabPanel
    {
        [SerializeField] private ColorPartUI partUI;
        private Vector3 _originalSize;

        public void AddNewPart<T>(T partName, Image partImage)
        {
            var propertyPartUI = Instantiate(partUI, transform.position, transform.rotation, transform);
            _originalSize = propertyPartUI.transform.localScale;
            propertyPartUI.transform.localScale = _originalSize;
            partUI.SetPart(partName, partImage);
        }
    }
}
