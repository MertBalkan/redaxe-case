using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEssentials.Extensions;

namespace RedAxeCase
{
    public class CarColorRandomizerSystem : ICarRandomizePart
    {
        public const string CarBodyMat = "Body";
        public const string CarRimMat = "Rim";

        private ICarController _carController;
        private ITabPanel _tabPanel;

        
        private MeshRenderer[] _meshRenderers;

        private Dictionary<ICarController, Material> _randomizedMaterials;

        public CarColorRandomizerSystem(ICarController carController, Dictionary<ICarController, Material> randomizedMaterials)
        {
            _carController = carController;
            var carControllerGo = _carController.Controller.gameObject;
            _randomizedMaterials = randomizedMaterials;
            
            _meshRenderers = carControllerGo.GetComponentsInChildren<MeshRenderer>();
            
        }
        
        public void Randomize(CarTabPanel tabPanel)
        {
            var randBodyColor = GetRandomColor();
            var randRimColor = GetRandomColor();

            foreach (var meshRenderer in _meshRenderers)
            {                  
                foreach (var mat in meshRenderer.materials)
                {
                    if (mat.name.Contains(CarBodyMat))
                        ChangeCarPartColor("Body ", mat, randBodyColor, tabPanel);
                    if (mat.name.Contains(CarRimMat))
                        ChangeCarPartColor("Tires ", mat, randRimColor, tabPanel);
                }
            }
        }

        private void ChangeCarPartColor(string part, Material mat, Color color, CarTabPanel tabPanel)
        {
            var colorPartPanel = tabPanel.GetComponentInChildren<ColorTabPanel>();

            mat.color = color;
            AddRandomizedMaterial(_carController, mat);

            colorPartPanel.AddNewPart(part + " Color: " + ExtColorToNames.FindColor(color), null);
        }
        

        private void AddRandomizedMaterial(ICarController carController, Material mat)
        {
            if(!_randomizedMaterials.ContainsKey(carController))
                _randomizedMaterials.Add(carController, mat);
        }

        private Color GetRandomColor() => Random.ColorHSV();
    }
}