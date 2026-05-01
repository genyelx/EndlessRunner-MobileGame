using UnityEngine;

public class DestroyRoad : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject)
        {
            Destroy(collision.gameObject);
        }
    }
}
