using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RedAxeCase
{
    public class CarSettingsCanvas : MonoBehaviour
    {
        [SerializeField] private RCC_CarControllerV3 carController;
        private List<ITabPanel> tabPanels;

        private void Awake()
        {
            tabPanels = GetComponentsInChildren<ITabPanel>().ToList();
        }

        private void Start()
        {
            foreach (var tabPanel in tabPanels) 
            {
                tabPanel.PrintSettings();
            }
        }
    }
}
