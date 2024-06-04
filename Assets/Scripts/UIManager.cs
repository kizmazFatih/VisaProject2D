using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;

    public void PlayFunction()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitFunction()
    {
        Application.Quit();
    }
}
