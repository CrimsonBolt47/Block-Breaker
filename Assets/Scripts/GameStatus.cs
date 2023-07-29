using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f,10f)][SerializeField] float gameSpeed=1f;

    [SerializeField] int pointsperblockdestroyed=83;
    [SerializeField] TextMeshProUGUI scoretext;
    [SerializeField] bool isAutoPlayEnabled;

    int maxHealth;
    [SerializeField] int currentHealthleft;//for debugging purposes
    [SerializeField] TextMeshProUGUI healthtext;

    [SerializeField] int currentscore = 0;



    private void Awake() //inbulit func this for when score dont restart when starting next level
    {

            int gamestatusCount = FindObjectsOfType<GameStatus>().Length; //when on second level 1 gamestatus object is destroyed so a new gamestatus
                                                                          //object runs so because of that score restrarts
            if (gamestatusCount > 1)
            {
                gameObject.SetActive(false);//bug fix not important(this helps when there is 2 gamestatus sometimes)
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(gameObject);
            }
    }

    private void Start()
    {
        scoretext.text = currentscore.ToString();
        InputHealth();
    }

    public void InputHealth()
    {
        currentHealthleft = maxHealth;
        healthtext.text = currentHealthleft.ToString();
    }

    void Update()
    {
        Time.timeScale = gameSpeed;
        
    }

    public void AddToScore()
    {
        currentscore = currentscore + pointsperblockdestroyed;
        scoretext.text = currentscore.ToString();


    }

    public void HealthDamage()
    {
        currentHealthleft--;
        healthtext.text = currentHealthleft.ToString();
    }
    public int ReturnCurrentHealth()
    {
        return currentHealthleft;
    }

    public void easy()
    {
        maxHealth = 10;
        InputHealth();
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void Medium()
    {
        maxHealth = 5;
        InputHealth();
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }

    public void Hard()
    {
        maxHealth = 3;
        InputHealth();
        FindObjectOfType<SceneLoader>().LoadNextScene();
    }



    public void ResestGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
