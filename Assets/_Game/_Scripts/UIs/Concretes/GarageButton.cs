using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RedAxeCase
{
    public class GarageButton : MonoBehaviour
    {
        [SerializeField] private Transform garageCam;
        public static int index = 0;
        private Vector3 _initialPos;

        private void Start()
        {
            index = 0;
            _initialPos = garageCam.position;
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
