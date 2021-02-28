using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class GameController : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject bestScorePanel;
    public GameObject misteryPanel;
    public GameObject endPanel;
    public Button RewardedAddButton;
    public Text scoreText;
    public AudioClip hitObstacle;
    public GameObject background;
    public int score = 0;
    public int additionalCoins = 0;
    public float spawnObstaclesDelay;
    public float spawnMisteriesDelay;
    public Vector3 spawnObstaclesSpeed;
    public Vector3 spawnMisteriesSpeed;
    bool start;
    bool secondChance = true;
    public bool testGame;
    public bool adWatched = false;
    public bool isBestScore = false;
    public int secondChanceScore = 0;
    public int secondChanceAdditionalCoins = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerSpawner>().SpawnPlayer(FindObjectOfType<SaveController>().save.currentBird);
        if(FindObjectOfType<SaveController>().save.currentBird == Save.BAT)
        {
            background.GetComponent<Image>().color = new Color32(255, 0, 0, 255);
        }
        startCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!start && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
    }
    public void UpdateScore()
    {
        if (FindObjectOfType<playerMove>().isAllive)
        {
            score++;
            if (score % 10 == 0 && score <= 90)
            {
                ChangeSpawnSpeedAndDelay();
            }
            if(score == 20)
            {
                ChangeSpawnSpeedAndDelay();
            }
            scoreText.text = score.ToString();
        }
    }
    public void ChangeSpawnSpeedAndDelay()
    {
        spawnObstaclesDelay -= 0.12f;
        spawnObstaclesSpeed -= new Vector3(0, 0.25f, 0);
    }
    public float GetSpawnDelay()
    {
        return spawnObstaclesDelay;
    }
    public Vector3 GetSpawnSpeed()
    {
        return spawnObstaclesSpeed;
    }
    public void RestartGame()
    {
        if (adWatched)
        {
            SaveCoinsFromAd();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void RestartGameFromPoint()
    {
        start = false;
        foreach(AutoMove am in FindObjectsOfType<AutoMove>())
        {
            if(am.gameObject.tag == "obstacle")
            {
                FindObjectOfType<spawnObstacles>().i--;
            }
            Destroy(am.gameObject);
        }
        FindObjectOfType<PlayerSpawner>().SpawnPlayer(FindObjectOfType<SaveController>().save.currentBird);
        startCanvas.SetActive(true);
        misteryPanel.SetActive(false);
        Time.timeScale = 0;
        secondChanceScore = score;
        secondChanceAdditionalCoins = additionalCoins;
        FindObjectOfType<spawnObstacles>().spawn = true;
        FindObjectOfType<spawnMisteries>().spawn = true;
        background.GetComponent<AutoMoveAndRotate>().enabled = true;
        FindObjectOfType<spawnObstacles>().secondChance = true;
        FindObjectOfType<spawnMisteries>().secondChance = true;
        FindObjectOfType<spawnObstacles>().StartSpawnAfterRestart();
        FindObjectOfType<spawnMisteries>().StartSpawnAfterRestart();
    }
    public void ReturnToMainMenu()
    {
        if (adWatched)
        {
            SaveCoinsFromAd();
        }
        SceneManager.LoadScene("StartScene");
    }

    public void SaveScoreAndCoins()
    {
        try
        {
            if (FindObjectOfType<SaveController>().save.bestScore < score)
            {
                if (!FindObjectOfType<SaveController>().save.skyIsNotTheLimit && score >= 20)
                {
                    FindObjectOfType<PlayServices>().UnlockSkyIsNotTheLimitAchievement();
                }
                if (!FindObjectOfType<SaveController>().save.reachTheMoon && score >= 130)
                {
                    FindObjectOfType<PlayServices>().UnlockAllOverTheMoonAchievement();
                }
                if (!FindObjectOfType<SaveController>().save.oneGiantStep && score >= 300)
                {
                    FindObjectOfType<PlayServices>().UnlockOneGiantStepAchievement();
                }
                FindObjectOfType<SaveController>().save.bestScore = score;
                isBestScore = true;
            }
            if (secondChance)
            {
                FindObjectOfType<SaveController>().save.coins += score + additionalCoins;
            }
            else
            {
                FindObjectOfType<SaveController>().save.coins += (score - secondChanceScore) + (additionalCoins - secondChanceAdditionalCoins);
            }
            

            PlayerPrefs.SetInt(Save.BEST_SCORE, FindObjectOfType<SaveController>().save.bestScore);
            PlayerPrefs.SetInt(Save.COINS, FindObjectOfType<SaveController>().save.coins);
            PlayerPrefs.SetInt(Save.RISK_TAKER, FindObjectOfType<SaveController>().save.riskTaker);
        }
        catch(Exception)
        {

        }
    }
    public void SetActiveBestScore()
    {
        if (isBestScore)
        {
            bestScorePanel.transform.GetChild(0).GetComponent<Text>().text = "New Best Score! \n" + score.ToString();
            bestScorePanel.SetActive(true);
            scoreText.text = "";
        }
    }
    
    public void SaveCoinsFromAd()
    {
        FindObjectOfType<SaveController>().save.coins += 15;
        PlayerPrefs.SetInt(Save.COINS, FindObjectOfType<SaveController>().save.coins);
    }
    public void AddAdditionalCoins()
    {
        additionalCoins += 5;
    }
    public void StartGame()
    {
        startCanvas.SetActive(false);
        FindObjectOfType<playerMove>().isAllive = true;
        start = true;
        Time.timeScale = 1;
    }
     public void MisteryActive(string name)
    {
        if(name == "big")
        {
            misteryPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(0f,10f,255f,255f);
            misteryPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(0f, 10f, 255f,255f);
        }
        else if(name == "small")
        {
            misteryPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(31f,222f,1f,255f);
            misteryPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(31f,222f,1f,255f);
        }
        else if(name == "reverse")
        {
            misteryPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(255f,0f,0f,255f);
            misteryPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(255f,0f,0f,255f);
        }
        else if(name == "coins")
        {
            misteryPanel.transform.GetChild(0).GetComponent<Image>().color = new Color(255,228,0);
            misteryPanel.transform.GetChild(1).GetComponent<Image>().color = new Color(255,228,0);
        }
        StartCoroutine("ActiveMistery");
        
    }
    IEnumerator ActiveMistery() 
    {
        misteryPanel.SetActive(true);
        yield return new WaitForSeconds(10);
        misteryPanel.SetActive(false);
    }

    public void StartRewardedAd()
    {
        FindObjectOfType<AddController>().ShowRewardedVideo("lvlSuccess");
        RewardedAddButton.interactable = false;
    }

    public void UpdateAdditionalCoins()
    {
        endPanel.transform.GetChild(0).GetComponent<Text>().text = "+" + (FindObjectOfType<GameController>().score + FindObjectOfType<GameController>().additionalCoins).ToString() + "$";
        adWatched = true;
    }
    public void PlaySoundOnHit()
    {
        AudioSource.PlayClipAtPoint(hitObstacle, Camera.main.transform.position, MusicController.GetEffectsVolume());
    }
    public void AddScoreToLeaderboard()
    {
        FindObjectOfType<PlayServices>().AddScoreToLeaderboard(score);
    }
    public void ShowLeaderboard()
    {
        FindObjectOfType<PlayServices>().ShowLeaderboard();
    }
    public void SetSecondChance()
    {
        secondChance = false;
    }
    public bool GetSecondChance()
    {
        return secondChance;
    }
}
