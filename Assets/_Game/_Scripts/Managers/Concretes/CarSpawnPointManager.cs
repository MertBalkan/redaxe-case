using System.Collections.Generic;
using UnityEngine;

namespace RedAxeCase
{
    public class CarSpawnPointManager : MonoBehaviour
    {
        [SerializeField] private List<Transform> cars;
        public List<Transform> Cars => cars;
        public int CarCount => cars.Count;
    }
}
