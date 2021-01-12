using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool _gamehasended = false;
    public float _gameoverdelay = 10f;

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Endgame()
    {
        if (_gamehasended == false)
        {
            _gamehasended = true;
            Debug.Log("GameOver");

            //show game over screen
            Invoke("Gameover", _gameoverdelay);
        }

    }

    void Gameover()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowTOPlay");
    }
}
