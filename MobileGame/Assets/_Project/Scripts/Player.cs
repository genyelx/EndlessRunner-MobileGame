using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private GameObject playerMesh;
    [SerializeField] private float speed;
    [SerializeField] private float stepSpeed;
    [SerializeField] private float currentLane = 0;
    [SerializeField] private float laneLimit = 1;

    [Header("Jump Settings")]
    [SerializeField] private Transform sensorGround;
    [SerializeField] private float sensorRadius;
    [SerializeField] private float jumpForce;

    public static int points = 0;

    private Vector3 currentPosition;

    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        rb = playerMesh.GetComponent<Rigidbody>();
        
        anim = playerMesh.GetComponent<Animator>();
        currentPosition = transform.position;
    }

    private void Update()
    {
        if (GameManager.inGame)
        {
            Move();
            anim.SetBool("pInGame", GameManager.inGame);
        }
    }

    bool OnGround()
    {
        return Physics.CheckSphere(sensorGround.position, sensorRadius, 1 << LayerMask.NameToLayer("Ground"));
    }

    private void Move()
    {        
        // MOVE NAS LATERAIS
        currentPosition = new Vector3(currentLane, currentPosition.y, currentPosition.z);

        // MOVE PARA FRENTE
        currentPosition.z += speed * Time.deltaTime;

        // ATUALIZA A POSICAO
        transform.position = Vector3.MoveTowards(transform.position, currentPosition, stepSpeed * Time.deltaTime);

        
    }

    public void ChangeLane(int direction)
    {
        if(direction < 0)
        {
            if(currentLane > -laneLimit)
            {
                currentLane += direction; 
            }
        }
        else if (direction > 0)
        {
            if (currentLane < laneLimit)
            {
                currentLane += direction;
            }
        }
    }


    public void Jump()
    {
        if (OnGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if (sensorGround != null) 
        {
            Gizmos.DrawSphere(sensorGround.position, sensorRadius);
        }       
    }
}
