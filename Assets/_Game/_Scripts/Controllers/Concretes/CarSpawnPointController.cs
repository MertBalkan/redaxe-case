using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class CarSpawnPointController : MonoBehaviour
    {
        private CarSpawnPointManager _carSpawnPointManager;

        private void Awake()
        {
            _carSpawnPointManager = GetComponentInParent<CarSpawnPointManager>();
        }

        private void Start()
        {
            int randomIndex = Random.Range(0, _carSpawnPointManager.CarCount);
            var car = Instantiate(_carSpawnPointManager.Cars[randomIndex], transform.localPosition, transform.localRotation);

            car.GetComponent<RCC_CarControllerV3>().canControl = false;
            CallCoroutines(car);
        }

        private void CallCoroutines(Transform car)
        {
            StartCoroutine(CallCarRandomizer(car));
            StopCoroutine(CallCarRandomizer(car));
        }

        static private IEnumerator CallCarRandomizer(Transform car)
        {
            yield return new WaitForSeconds(0.01f);
            car.GetComponent<CarPartRandomizerLoader>().StartRandomizer();
        }
    }
}
