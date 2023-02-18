using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManagerScene : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level0");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }
}
