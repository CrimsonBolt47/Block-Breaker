using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameStatus>().HealthDamage();
        if (FindObjectOfType<GameStatus>().ReturnCurrentHealth() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            FindObjectOfType<Ball>().MakehasStartedFalse();
        }
        
        
    }
}
