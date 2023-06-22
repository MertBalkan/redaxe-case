using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarColorRandomizerSystem : ICarRandomizePart
    {
        public const string CarBodyMat = "Body";
        public const string CarRimMat = "Rim";

        private ICarController _carController;
        private ITabPanel _tabPanel;

        
        private MeshRenderer[] _meshRenderers;

        private List<Material> _randomizedMaterials;

        public CarColorRandomizerSystem(ICarController carController, List<Material> randomizedMaterials)
        {
            _carController = carController;
            var carControllerGo = _carController.Controller.gameObject;
            _randomizedMaterials = randomizedMaterials;
            
            _meshRenderers = carControllerGo.GetComponentsInChildren<MeshRenderer>();
            
            _randomizedMaterials = new List<Material>();
        }
        
        public void Randomize(BasePartPanel partPanel)
        {
            var randBodyColor = GetRandomColor();
            var randRimColor = GetRandomColor();

            foreach (var meshRenderer in _meshRenderers)
            {                  
                foreach (var mat in meshRenderer.materials)
                {
                    if (mat.name.Contains(CarBodyMat))
                        ChangeCarPartColor(mat, randBodyColor);
                    if (mat.name.Contains(CarRimMat))
                        ChangeCarPartColor(mat, randRimColor);
                }
            }
        }

        private void ChangeCarPartColor(Material mat, Color color)
        {
            mat.color = color;
            AddRandomizedMaterial(mat);
        }
        

        private void AddRandomizedMaterial(Material mat)
        {
            if (!_randomizedMaterials.Contains(mat)) 
                _randomizedMaterials.Add(mat);
        }

        private Color GetRandomColor() => Random.ColorHSV();
    }
}