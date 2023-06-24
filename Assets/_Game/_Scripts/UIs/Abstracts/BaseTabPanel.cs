using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public abstract class BaseTabPanel : MonoBehaviour
    {
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.4f);
            gameObject.SetActive(false);
        }
    }
}