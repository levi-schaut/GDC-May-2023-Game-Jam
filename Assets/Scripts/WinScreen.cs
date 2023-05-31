using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
