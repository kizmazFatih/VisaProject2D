using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private Canvas thisCanvas;
    public TextMeshProUGUI text;


    void Start()
    {
        thisCanvas = GetComponent<Canvas>();
        thisCanvas.enabled = false;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (!CharacterHealth.instance.death)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (thisCanvas.enabled == false)
                {
                    Pause();
                }
                else
                {
                    CloseTab();
                }
            }
        }
        else
        {
            Pause();
            text.text = "You Died";
            text.color = Color.red;
        }

        if (Movement.instance.gameEnded)
        {
            Pause();
        }
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void CloseTab()
    {
        if (!CharacterHealth.instance.death)
        {
            thisCanvas.enabled = false;
            Time.timeScale = 1;
        }
    }
    void Pause()
    {
        thisCanvas.enabled = true;
        Time.timeScale = 0;
        if (Movement.instance.gameEnded)
        {
            text.text = "Succesed";
            text.color = new Color(22, 247, 66, 255);
        }
        else
        {
            text.text = "Pause";
            text.color = new Color(135, 155, 149, 255);
        }
    }


}
