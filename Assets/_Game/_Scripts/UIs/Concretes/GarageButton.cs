using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace RedAxeCase
{
    public class GarageButton : MonoBehaviour
    {
        // TODO: BARGAIN SYSTEM CONNECTION
        [SerializeField] private Transform garageCam;
        [SerializeField] private CarSettingsCanvas[] carSettingsCanvas;
        
        public static int index = 0;
        
        private Vector3 _initialPos;

        private void Awake()
        {
            carSettingsCanvas = FindObjectsOfType<CarSettingsCanvas>();
        }

        private void Start()
        {
            _initialPos = garageCam.position;
            index = 0;         
        }


        private void Update()
        {
            SetIndex();
        }

        private void SetIndex()
        {
            switch (index)
            {
                case 0:
                    garageCam.transform.position = _initialPos;
                    break;
                case 1:
                    garageCam.transform.position = new Vector3(10, garageCam.transform.position.y, garageCam.transform.position.z);
                    break;
                case 2:
                    garageCam.transform.position = new Vector3(10, garageCam.transform.position.y, 18.41f);
                    break;
                case 3:
                    garageCam.transform.position = new Vector3(-5.46f, garageCam.transform.position.y, 18.41f);
                    break;
                case 4:
                    garageCam.transform.position = _initialPos;
                    break;
            }
        }

        public void RightButtonPressed()
        {
            if (index >= 4) index = 0;
            index++;
        }
    }
}