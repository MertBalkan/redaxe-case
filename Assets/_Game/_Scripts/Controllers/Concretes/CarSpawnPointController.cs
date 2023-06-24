using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RedAxeCase
{
    public class CarSpawnPointController : MonoBehaviour
    {
        [SerializeField] private CarSettingsCanvas carSettingsCanvas;
        [SerializeField] private bool leftLook;
        [SerializeField] private float canvasSpawnRot = 45;
        
        private CarSpawnPointManager _carSpawnPointManager;

        private void Awake()
        {
            _carSpawnPointManager = GetComponentInParent<CarSpawnPointManager>();
        }

        private void Start()
        {
            int randomIndex = Random.Range(0, _carSpawnPointManager.CarCount);
            
            var car = Instantiate(_carSpawnPointManager.Cars[randomIndex], transform.localPosition, transform.localRotation);
            // car.GetComponent<CarPartRandomizerLoader>().InitRandomizers();
            
            var carRcc = car.GetComponent<RCC_CarControllerV3>();
            var carController = car.GetComponent<CarController>();

            carRcc.canControl = false;
            
            // CallCoroutines(car);
            // car.GetComponent<CarPartRandomizerLoader>().StartRandomizer();

            Quaternion quat = new Quaternion();

            quat = leftLook ? quat = Quaternion.Euler(0, transform.rotation.y - canvasSpawnRot, 0) :  quat = Quaternion.Euler(0, transform.rotation.y + canvasSpawnRot, 0);
            var canvasSettingsGo = Instantiate(carSettingsCanvas, transform.localPosition + new Vector3(2, 5, 2), quat);

            canvasSettingsGo.CarController = carController;

        }

        private void CallCoroutines(Transform car)
        {
            StartCoroutine(CallCarRandomizer(car));
            StopCoroutine(CallCarRandomizer(car));
        }

        static private IEnumerator CallCarRandomizer(Transform car)
        {
            yield return new WaitForSeconds(0.1f);
        }
    }
}
