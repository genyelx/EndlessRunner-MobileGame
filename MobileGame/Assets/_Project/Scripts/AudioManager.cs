using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] clips;
    [SerializeField] Collisions collisions;
    [SerializeField] Player playerScript;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(collisions.coliderFishBone)
        {
            audioSource.PlayOneShot(clips[0]);
            collisions.coliderFishBone = false;
        }

        if(collisions.coliderObstacle)
        {
            audioSource.PlayOneShot(clips[1]);
            audioSource.PlayOneShot(clips[2]);
            audioSource.clip = clips[4];
            audioSource.volume = 0.5f;
            audioSource.Play();
            audioSource.loop = true;
            collisions.coliderObstacle = false;
        }

        if(playerScript.completeMission)
        {
            playerScript.completeMission = false;
            audioSource.PlayOneShot(clips[5]);
            audioSource.volume = 0.5f;
            audioSource.Play();
            audioSource.loop = false;
        }

        if(playerScript.OnGround() == false)
        {
            audioSource.PlayOneShot(clips[6]);
            audioSource.Play();
        }
    }
}
