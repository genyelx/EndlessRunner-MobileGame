using UnityEngine;

public class Collisions : MonoBehaviour
{
    [SerializeField] Player playerScript;
    public Animator anim;
    public bool coliderObstacle;
    public bool coliderFishBone;

    private void Start()
    {
        anim = GetComponent<Animator>();
        coliderObstacle = false;
        coliderFishBone = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "FishBone")
        {
            coliderFishBone = true;
            Destroy(collision.gameObject);
            playerScript.coins++;
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            coliderObstacle = true;
            playerScript.speed = 0;
            anim.SetBool("pDie", coliderObstacle);
        }
    }
}
