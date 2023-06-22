using UnityEngine;

namespace RedAxeCase
{
    public static class CursorMode
    {
        public static void SetCursorMode(bool mode)
        {
            if (mode)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
