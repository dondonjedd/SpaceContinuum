using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;
    public void Crash() { 
        gameObject.SetActive(false);
        gameOver.endGame();
        
    }

    public void restart()
    {
        gameObject.SetActive(true);

    }
}
