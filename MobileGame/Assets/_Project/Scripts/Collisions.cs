using UnityEngine;

public class Collisions : MonoBehaviour
{
    [Header("AudioClips")]
    public AudioClip[] audioclips;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FishBone")
        {
            Destroy(collision.gameObject);
            audioSource.clip = audioclips[0];
            audioSource.Play();
            Player.points++;
        }
    }
}
