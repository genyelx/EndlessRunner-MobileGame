using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathSceneManager : MonoBehaviour
{
    [SerializeField] Button buttonTryAgain;
    [SerializeField] Button buttonExit;

    private void Start()
    {
        buttonTryAgain.onClick.AddListener(TryAgain);
        buttonExit.onClick.AddListener(ExitGame);
    }

    void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
    
    void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
