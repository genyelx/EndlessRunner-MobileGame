using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerStartScene : MonoBehaviour
{
    Touch touch;
    private float blinkDuration = 1f;
    private float blinkInterval = 0.1f;
    [SerializeField] Text textStart;


    private void Start()
    {
        StartCoroutine(BlinkCouroutine());
    }

    void Update()
    {
        touch = Input.GetTouch(0);
        if(touch.phase == TouchPhase.Began)
        {
            SceneManager.LoadScene("TestGame");
        }
    }

    IEnumerator BlinkCouroutine()
    {
        float elapsedTime = 0f;
        bool visible = true;

        while (elapsedTime < blinkDuration)
        {
            visible = !visible;
            textStart.enabled = visible;

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        StartCoroutine(BlinkCouroutine());

        textStart.enabled = true;

    }
}
