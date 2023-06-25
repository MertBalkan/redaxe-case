using UnityEngine;

namespace RedAxeCase
{
    public class CanvasSpawner : MonoBehaviour
    {
        [SerializeField] private CarSettingsCanvas carSettingsCanvas;
        [SerializeField] private bool leftLook;
        [SerializeField] private float canvasSpawnRot = 45;
        
        private SpawnPointController _spawnPointController;

        private void Awake()
        {
            _spawnPointController = GetComponent<SpawnPointController>();
        }

        private void Start()
        {
            _spawnPointController.OnUISpawn += HandleOnSpawn;
        }

        private void OnDisable()
        {
            _spawnPointController.OnUISpawn -= HandleOnSpawn;
        }

        public void HandleOnSpawn(CarController carController)
        {
            var quat = new Quaternion();

            quat = leftLook ? 
            quat = Quaternion.Euler(0, transform.rotation.y - canvasSpawnRot, 0) :  
            quat = Quaternion.Euler(0, transform.rotation.y + canvasSpawnRot, 0);
            
            var canvasSettingsGo = Instantiate(carSettingsCanvas, transform.localPosition + new Vector3(2, 5, 2), quat);

            canvasSettingsGo.CarController = carController;
            carController.CarTabPanel = canvasSettingsGo.GetComponentInChildren<CarTabPanel>();
        }
    }
}
