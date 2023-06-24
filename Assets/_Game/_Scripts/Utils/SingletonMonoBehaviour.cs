using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : SingletonMonoBehaviour<T>
    {
        public static T Instance;
        protected static T I => Instance;
    
        protected virtual void Awake()
        {
            if (Instance != null && Instance != this) 
                Destroy(this); 
            else 
                Instance = (T)this; 
        }
    }
}
