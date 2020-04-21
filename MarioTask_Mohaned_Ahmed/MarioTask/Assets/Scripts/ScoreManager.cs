using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int startTimeSeconds = 400;

    private int winningTime;
    public bool Win = false;

    private float currentTime = 0;
    private int score = 0;
    private int coins = 0;

    private int goombaKillSpreeCounter = 0;
    private float goombaLastKillTimer = 0;

    [SerializeField] Text countdownText;
    [SerializeField] Text scoreText;
    [SerializeField] Text coinsText;

    void Awake()
    {
        currentTime = startTimeSeconds;
    }

    void Update()
    {
        if (!Win)
        {
            currentTime = currentTime - Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
        
        scoreText.text = score.ToString("0");
        coinsText.text = coins.ToString();

        goombaLastKillTimer = goombaLastKillTimer + Time.deltaTime;

        if (score > 2000)
        {
            //UnityEngine.Diagnostics.Utils.ForceCrash(UnityEngine.Diagnostics.ForcedCrashCategory.AccessViolation);
        }

        if (currentTime <= 0)
        {
            //RESTART
            gameObject.GetComponent<PlayerController>().Die();
            //Application.LoadLevel("Level1");
        }

    }
    ////GETS///////////////////////
    public float GetCurrentTime()
    {
        return currentTime;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

    ////OTHER METHODS///////////////
    public void Goomba()
    {
        if (goombaLastKillTimer > 0.5f) //If Goomba was killed more than 0.5 seconds ago, we don't care about it
            goombaKillSpreeCounter = 0;
		
        score += (100 * (2 * goombaKillSpreeCounter)); //More killing, more score

        if (goombaKillSpreeCounter == 0) //Score that we add if no Goomba was killed in the last 0.5 seconds
            score += 100;

        goombaKillSpreeCounter++;
        goombaLastKillTimer = 0f;
    }

    public void Mushroom()
    {
        score += 1000;
    }

    public void Coin()
    {
        score += 200;
        coins++;
    }

    public void Brick()
    {
        score += 50;
    }

    public void FreezeConvertTimeToscore()
    {
        winningTime = (int)currentTime;
        countdownText.text = winningTime.ToString("0");
        score += winningTime;
    }
}
