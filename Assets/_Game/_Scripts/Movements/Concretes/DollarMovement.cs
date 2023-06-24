using UnityEngine;

namespace RedAxeCase
{
    public class DollarMovement : MonoBehaviour
    {
        void Update()
        {
            transform.position = new Vector3(transform.position.x, 3 + Mathf.PingPong(Time.time, .5f), transform.position.z);
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        }
    }
}
