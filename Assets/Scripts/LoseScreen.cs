using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject loseScreen;

    public void LoseGame()
    {
        CinemachineShake.Instance.StopShaking();
        loseScreen.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void TryAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
