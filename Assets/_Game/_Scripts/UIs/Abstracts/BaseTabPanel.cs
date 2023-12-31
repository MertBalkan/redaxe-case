using System;
using System.Collections;
using UnityEngine;

namespace RedAxeCase
{
    public abstract class BaseTabPanel<T> : MonoBehaviour where T : BaseCarPartUI
    {
        [SerializeField] private T partUI;
        private Vector3 _originalSize;
        
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(StartDelayTimeConst.TabPanelDisableDelayTime);
            gameObject.SetActive(false);
        }

        public void AddNewPart<T>(T partName)
        {
            var propertyPartUI = Instantiate(partUI, transform.position, transform.rotation, transform);
            _originalSize = propertyPartUI.transform.localScale;
            propertyPartUI.transform.localScale = _originalSize;
            partUI.SetPart(partName);
        }
    }
}