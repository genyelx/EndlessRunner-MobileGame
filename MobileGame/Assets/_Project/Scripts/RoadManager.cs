using UnityEngine;

public class RoadManager : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabRoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enter")
        {
            Instantiate(prefabRoad[Random.Range(0,3)], new Vector3(0, 0, transform.position.z + 10f), Quaternion.identity);
        }
    }
}
