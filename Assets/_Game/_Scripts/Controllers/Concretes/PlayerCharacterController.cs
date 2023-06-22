using System;
using UnityEngine;

namespace RedAxeCase
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                CursorMode.SetCursorMode(true);
            }
        }
    }
}
