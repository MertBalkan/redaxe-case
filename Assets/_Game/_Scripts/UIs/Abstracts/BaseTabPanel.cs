using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public abstract class BaseTabPanel<T> : MonoBehaviour where T : BaseCarPartUI
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);
        }

        [SerializeField] private T partUI;
        private Vector3 _originalSize;

        public void AddNewPart<T>(T partName, Image partImage)
        {
            Debug.Log("partUI.name = " + partUI.name);

            var propertyPartUI = Instantiate(partUI, transform.position, transform.rotation, transform);
            _originalSize = propertyPartUI.transform.localScale;
            propertyPartUI.transform.localScale = _originalSize;
            partUI.SetPart(partName, partImage);
        }
    }
}