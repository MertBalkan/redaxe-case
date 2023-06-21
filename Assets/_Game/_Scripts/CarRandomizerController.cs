using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    [Serializable]
    public struct ColorRandomizer
    { 
        private MeshRenderer[] _meshRenderers;
            
        public const string CarBodyMat = "Body";
        public const string CarRimMat = "Rim";

        public MeshRenderer[] MeshRenderers { get => _meshRenderers; set => _meshRenderers = value; }
        public List<Material> randomizedMaterials;

        public bool IsMaterialsEmpty => randomizedMaterials.Count <= 0;

        public void AddRandomizedMaterial(Material mat)
        {
            if (!randomizedMaterials.Contains(mat)) randomizedMaterials.Add(mat);
        }
    }

    public struct DamageRandomizer
    {
        public Rigidbody[] damagableParts;
    }
    

    [Serializable]
    public struct CarPropertyRandomizer
    {
        public float carSpeed;
        public float engineTorque;
    }
    
    public class CarRandomizerController : MonoBehaviour
    {
        [SerializeField] private ColorRandomizer colorRandomizer;
        [SerializeField] private CarPropertyRandomizer carPropertyRandomizer;

        private void Awake()
        {
            colorRandomizer.MeshRenderers = GetComponentsInChildren<MeshRenderer>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                var randBodyColor = GetRandomColor();
                var randRimColor = GetRandomColor();

                foreach (var meshRenderer in colorRandomizer.MeshRenderers)
                {                  
                    foreach (var mat in meshRenderer.materials)
                    {
                        if (mat.name.Contains(ColorRandomizer.CarBodyMat))
                        {
                            mat.color = randBodyColor;
                            colorRandomizer.AddRandomizedMaterial(mat);
                        }
                        if (mat.name.Contains(ColorRandomizer.CarRimMat))
                        {
                            mat.color = randRimColor;
                            colorRandomizer.AddRandomizedMaterial(mat);
                        }
                    }
                }

                carPropertyRandomizer.carSpeed = Random.Range(200, 280);
                carPropertyRandomizer.engineTorque = Random.Range(350, 480);

            }
        }

        private Color GetRandomColor() => Random.ColorHSV();
    }
}