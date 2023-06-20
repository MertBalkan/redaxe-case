//----------------------------------------------
//			Realistic Car Controller
//
// Copyright © 2023 BoneCracker Games
// http://www.bonecrackergames.com
//
//----------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// UI change wheel button.
/// </summary>
[AddComponentMenu("BoneCracker Games/Realistic Car Controller/UI/Modification/RCC UI Wheel Button")]
public class RCC_UI_Wheel : MonoBehaviour {

    public int wheelIndex = 0;

    public void OnClick() {

        RCC_CustomizationManager handler = RCC_CustomizationManager.Instance;
        handler.ChangeWheels(wheelIndex);

    }

}
