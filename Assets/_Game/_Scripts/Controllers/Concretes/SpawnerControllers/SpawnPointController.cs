using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class SpawnPointController : MonoBehaviour
    {
        private SpawnPointManager _spawnPointManager;
        private CarController _carController;

        // first spawn uis, then entities
        public System.Action<CarController> OnEntitySpawn;
        public System.Action<CarController> OnUISpawn;

        private void Awake()
        {
            _spawnPointManager = GetComponentInParent<SpawnPointManager>();
            var randomIndex = Random.Range(0, _spawnPointManager.CarCount);
            var car = Instantiate(_spawnPointManager.Cars[randomIndex], transform.localPosition, transform.localRotation);

            _carController = car.GetComponent<CarController>();
        }

        private IEnumerator Start()
        {            
            yield return new WaitForSeconds(0.1f * Time.deltaTime);
            OnUISpawn?.Invoke(_carController);
            yield return new WaitForSeconds(0.2f * Time.deltaTime);
            OnEntitySpawn?.Invoke(_carController);
        }
    }
}