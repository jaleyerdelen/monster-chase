using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public class GamePlayUIController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay"); // 1.yol
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 2.yol
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
  
}
