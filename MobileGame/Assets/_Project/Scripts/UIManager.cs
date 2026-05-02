using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Canvas Delay Settings")]
    [SerializeField] private Canvas canvasDelay;
    [SerializeField] private Text textDelay;

    [Header("Canvas Hud Game")]
    [SerializeField] private Canvas canvasHudGame;
    [SerializeField] private Text textCoin;
    [SerializeField] private Text textPoints;

    [Header("Canvas Died")]
    [SerializeField] private Canvas canvasDiedGame;

    [Header("Canvas Missions")]
    [SerializeField] private Canvas canvasMissions;
    [SerializeField] private Animator canvasAnimMissions;
    private float blinkDuration = 1f;
    private float blinkInterval = 0.3f;

    [Header("Canvas Complete Mission")]
    [SerializeField] private Canvas canvasCompleteMission;

    [Header("Scripts References")]
    [SerializeField] Player playerScript;
    [SerializeField] Collisions collisions;

    void Start()
    {
        canvasDelay.enabled = false;
        canvasCompleteMission.enabled = false;
        StartCoroutine(BlinkCouroutine());
    }

    void Update()
    {
        if (!GameManager.inGame)
        {
            textDelay.text = GameManager.delayStartGame.ToString();
            canvasDelay.enabled = true;
            canvasHudGame.enabled = false;

            if (GameManager.delayStartGame == 0)
            {
                textDelay.text = "GO!";
            }
        }
        else
        {
            canvasDelay.enabled = false;
            canvasHudGame.enabled = true;
        }

        if(GameManager.inGame)
        {
            StopCoroutine(BlinkCouroutine());
            canvasAnimMissions.SetBool("pInGame", GameManager.inGame);
        }

        if(!collisions.coliderObstacle)
        {
            canvasDiedGame.enabled = false;
        }
        else
        {
            canvasDiedGame.enabled = true;
        } 
            
            textCoin.text = playerScript.coins.ToString();
            textPoints.text = playerScript.points.ToString();

        if (playerScript.points == 10000)
        {
            canvasCompleteMission.enabled = true;
        }
    }

    IEnumerator BlinkCouroutine()
    {
        float elapsedTime = 0f;
        bool visible = true;

        while (elapsedTime < blinkDuration)
        {
            visible = !visible;
            canvasMissions.enabled = visible;

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        StartCoroutine(BlinkCouroutine());

        canvasMissions.enabled = true;

    }
}
