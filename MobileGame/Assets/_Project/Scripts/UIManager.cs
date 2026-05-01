using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas Delay Settings")]
    [SerializeField] private Canvas canvasDelay;
    [SerializeField] private Text textDelay;

    [Header("Canvas Hud Settings")]
    [SerializeField] private Text textCoin;

    private Player playerScript;

    private void Awake()
    {
        playerScript = GetComponent<Player>();
    }

    void Start()
    {
        canvasDelay.enabled = true;       
    }


    void Update()
    {
        if (!GameManager.inGame)
        {
            textDelay.text = GameManager.delayStartGame.ToString();

            if(GameManager.delayStartGame == 0)
            {
                textDelay.text = "GO!";
            }
        }
        else
        {
            canvasDelay.enabled = false;
        }

        textCoin.text = Player.points.ToString();
    }
}
