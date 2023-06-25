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

        private CarController _carController;
        private ITabPanel _tabPanel;

        
        private MeshRenderer[] _meshRenderers;

        private Dictionary<ICarController, Material> _randomizedMaterials;

        public CarColorRandomizerSystem(CarController carController, Dictionary<ICarController, Material> randomizedMaterials)
        {
            _carController = carController;
            var carControllerGo = _carController.Controller.gameObject;
            _randomizedMaterials = randomizedMaterials;
            
            _meshRenderers = carControllerGo.GetComponentsInChildren<MeshRenderer>();
            
        }
        
        public void Randomize(CarTabPanel tabPanel)
        {
            int randomizeBodyColor = Random.Range(0, 2);
            if (randomizeBodyColor == 1)
            {
                var randBodyColor = GetRandomColor();
                foreach (var meshRenderer in _meshRenderers)
                {                  
                    foreach (var mat in meshRenderer.materials)
                    {
                        if (mat.name.Contains(CarBodyMat))
                            ChangeCarPartColor("Body ", mat, randBodyColor, tabPanel);
                    }
                }
            }
            else
            {
                ChangeCarPartColor("Body: Default Color", null, Color.black, tabPanel);
            }
            
            int randomizeRimColor = Random.Range(0, 2);
            
            if (randomizeRimColor == 1)
            {
                var randRimColor = GetRandomColor();
                foreach (var meshRenderer in _meshRenderers)
                {                  
                    foreach (var mat in meshRenderer.materials)
                    {
                        if (mat.name.Contains(CarRimMat))
                            ChangeCarPartColor("Tires ", mat, randRimColor, tabPanel);
                    }
                }

                CarCostCalculatorManager.Instance.carCostDictionary[_carController] *= 5;
            }
            else
            {
                ChangeCarPartColor("Tires: Default Color", null, Color.black, tabPanel);
            }
        }

        private void ChangeCarPartColor(string part, Material mat, Color color, CarTabPanel tabPanel)
        {
            var colorPartPanel = tabPanel.GetComponentInChildren<ColorTabPanel>();

            if(mat == null)
            {
                colorPartPanel.AddNewPart(part);
                return;
            }
            

            mat.color = color;
            AddRandomizedMaterial(_carController, mat);

            colorPartPanel.AddNewPart(part + " Color: " + ExtColorToNames.FindColor(color));
        }
        

        private void AddRandomizedMaterial(ICarController carController, Material mat)
        {
            if (mat == null)
            {
                return;
            }
            if(!_randomizedMaterials.ContainsKey(carController))
                _randomizedMaterials.Add(carController, mat);
        }

        private Color GetRandomColor() => Random.ColorHSV();
    }
}