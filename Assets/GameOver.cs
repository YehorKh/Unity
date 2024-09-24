using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public bool isGameOver = false;
    void Start()
    {
        
    }
    public void EndGame()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            RestartGame();
        }
    }

     void RestartGame()
    {
        Application.LoadLevel(0);

    }
     void Update()
    {
        
    }
}
