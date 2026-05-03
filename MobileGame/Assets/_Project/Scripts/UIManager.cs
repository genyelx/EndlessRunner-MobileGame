using System.Collections;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    private int delayStartGame = 3;

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

        if(collisions.coliderObstacle)
        {
            StartCoroutine(TimeToDiedScene());
        }

            textCoin.text = playerScript.coins.ToString();
            textPoints.text = playerScript.points.ToString();

        if (playerScript.points == 10000)
        {
            canvasCompleteMission.enabled = true;
        }

    }

    IEnumerator TimeToDiedScene()
    {
        while (delayStartGame > 0)
        {
            yield return new WaitForSeconds(1.0f);
            delayStartGame--;
        }

        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("DiedScene");
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
