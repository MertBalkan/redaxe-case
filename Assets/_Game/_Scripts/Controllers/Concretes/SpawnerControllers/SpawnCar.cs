using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class SpawnCar : MonoBehaviour
    {
        private SpawnPointController _spawnPointController;

        private void Awake()
        {
            _spawnPointController = GetComponentInParent<SpawnPointController>();
        }

        private void Start()
        {
            _spawnPointController.OnEntitySpawn += DisableRcc;
        }

        private void OnDisable()
        {
            _spawnPointController.OnEntitySpawn -= DisableRcc;
        }

        public void DisableRcc(CarController carController)
        {
            var carRcc = carController.GetComponent<RCC_CarControllerV3>();
            carRcc.enabled = false;
        }
    }
}