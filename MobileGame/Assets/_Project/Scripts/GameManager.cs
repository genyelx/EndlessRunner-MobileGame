using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int delayStartGame = 3;
    public static bool inGame = false;

    void Start()
    {
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
