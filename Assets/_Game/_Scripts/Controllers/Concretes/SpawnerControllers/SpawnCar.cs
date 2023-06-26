using UnityEngine;

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
            _spawnPointController.OnEntitySpawn += DisableRccAndCam;
        }

        private void OnDisable()
        {
            _spawnPointController.OnEntitySpawn -= DisableRccAndCam;
        }

        private void DisableRccAndCam(CarController carController)
        {
            var carRcc = carController.GetComponent<RCC_CarControllerV3>();
            carRcc.enabled = false;
            DisableCameras();
        }

        private void DisableCameras()
        {
            var carRccCams = FindObjectsOfType<RCC_Camera>();
            foreach (var carRccCam in carRccCams)
                carRccCam.gameObject.SetActive(false);
        }
    }
}