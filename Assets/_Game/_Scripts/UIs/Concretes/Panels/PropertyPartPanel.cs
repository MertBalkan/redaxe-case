using UnityEditor;
using UnityEngine;

namespace RedAxeCase
{
    public class PropertyPartPanel : BasePartPanel, ITabPanel
    {
        [SerializeField] private PropertyPartUI propertyPartUI;
        public GameObject MyParent;
        private Vector3 originalSize;
        public void PrintSettings()
        {
            Debug.Log("Property Part Panel Print");            
        }
        
        public void AddNewPart()
        {
            var mChild = Instantiate(propertyPartUI, MyParent.transform.position, MyParent.transform.rotation);
            originalSize = mChild.transform.localScale;
            mChild.transform.SetParent(MyParent.transform);
            mChild.transform.localScale = originalSize;
        }
    }
}
