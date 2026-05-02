using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameManager : MonoBehaviour
{
    Touch touch;
    public static int delayStartGame = 3;
    public static bool inGame = false;

    private void Update()
    {
        if (Input.touchCount == 0)
        {
            return;
        }

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        while(delayStartGame > 0)
        {            
            yield return new WaitForSeconds(1.0f);
            delayStartGame--;
        }

        yield return new WaitForSeconds(1.0f);
        inGame = true;
    }        


}
