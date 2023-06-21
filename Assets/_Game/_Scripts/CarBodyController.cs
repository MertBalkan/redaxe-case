using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class CarBodyController : MonoBehaviour
    {
        private MeshRenderer[] meshRenderers;
            
        private const string carBodyMat = "Body";
        private const string carRimMat = "Rim";

        private void Awake()
        {
            meshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                var randBodyColor = GetRandomColor();
                var randTireColor = GetRandomColor();

                foreach (var meshRenderer in meshRenderers)
                {                  
                    foreach (var mat in meshRenderer.materials)
                    {
                        if (mat.name.Contains(carBodyMat))
                            mat.color = randBodyColor;
                        if (mat.name.Contains(carRimMat))
                            mat.color = randTireColor;
                    }
                }
            }
        }

        private Color GetRandomColor() => Random.ColorHSV();
    }
}