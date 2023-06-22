using System;
using UnityEngine;

namespace RedAxeCase
{
    public abstract class BasePartPanel : MonoBehaviour
    {
        protected void Start()
        {
            gameObject.SetActive(false);
        }

    }
}
