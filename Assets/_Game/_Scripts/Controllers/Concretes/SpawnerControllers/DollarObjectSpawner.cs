using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RedAxeCase
{
    public class DollarObjectSpawner : MonoBehaviour
    {
        [SerializeField] private DollarController dollar;
        private SpawnPointController _spawnPointController;

        private void Awake()
        {
            _spawnPointController = GetComponent<SpawnPointController>();
        }

        private void Start()
        {
            _spawnPointController.OnEntitySpawn += HandleOnSpawn;
        }

        private void OnDisable()
        {
            _spawnPointController.OnEntitySpawn -= HandleOnSpawn;
        }
        
        private void HandleOnSpawn(CarController carController)
        {
            var dollarController = Instantiate(dollar, transform.position + new Vector3(-3, 2, -3), Quaternion.identity);
            dollarController.SetCostToUI(carController);
        }
    }
}
