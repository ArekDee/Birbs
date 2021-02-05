using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class PlayServices : MonoBehaviour
{
    private static PlayServices _instance;

    public static PlayServices Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        try
        {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            //Social.localUser.Authenticate((bool success) => { });
            PlayGamesPlatform.Instance.Authenticate((bool success) => { });
        }
        catch (Exception exception)
        {
            Debug.Log(exception);
        }
    }

    public void AddScoreToLeaderboard(int score)
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            int playScore = GetPlayerBestScore();
            int localScore = FindObjectOfType<SaveController>().save.bestScore;
            if (playScore != 0 && playScore < localScore)
            {
                PlayGamesPlatform.Instance.ReportScore(localScore, "CgkIr4jp8OcREAIQAw", success => { });
            }
            else
            {
                PlayGamesPlatform.Instance.ReportScore(score, "CgkIr4jp8OcREAIQAw", success => { });
            }

            if(playScore > localScore)
            {
                FindObjectOfType<SaveController>().save.bestScore = playScore;
                PlayerPrefs.SetInt(Save.BEST_SCORE, FindObjectOfType<SaveController>().save.bestScore);
            }
        }
    }
    public void ShowLeaderboard()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ShowLeaderboardUI();
        else
            PlayGamesPlatform.Instance.Authenticate((bool success) =>
            {
                PlayGamesPlatform.Instance.ShowLeaderboardUI();
            });
    }
    public int GetPlayerBestScore()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            int score = 0;

            PlayGamesPlatform.Instance.LoadScores(
             "CgkIr4jp8OcREAIQAw",
             LeaderboardStart.PlayerCentered,
             1,
             LeaderboardCollection.Public,
             LeaderboardTimeSpan.AllTime,
         (LeaderboardScoreData data) =>
         {
             score = (int)data.Scores[0].value;
         });
            return score;

        }
        return 0;
    }
    public void ShowAchievements()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ShowAchievementsUI();
        else
            PlayGamesPlatform.Instance.Authenticate((bool success) =>
            {
                PlayGamesPlatform.Instance.ShowAchievementsUI();
            });
    }

    public void UnlockFirstTryAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
        {
            FindObjectOfType<SaveController>().save.firstgame = true;
            PlayerPrefs.SetInt(Save.FIRST_GAME, 1);
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQAQ", 100f, success => { });
        }
    }
    public void UnlockOrnitchologistAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQBA", 100f, success => { });
    }
    public void UnlockExpertAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQBQ", 100f, success => { });
    }
    public void UnlockAllOverTheMoonAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQBg", 100f, success => { });
    }
    public void UnlockSkyIsNotTheLimitAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQBw", 100f, success => { });
    }
    public void UnlockOneGiantStepAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQCA", 100f, success => { });
    }
    public void UnlockBirbCollectorAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQCQ", 100f, success => { });
    }
    public void UnlockNeverGiveUpAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQCg", 100f, success => { });
    }
    public void UnlockSecondChanceAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQCw", 100f, success => { });
    }
    public void UnlockRiskTakerAchievement()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated())
            PlayGamesPlatform.Instance.ReportProgress("CgkIr4jp8OcREAIQDA", 100f, success => { });
    }

    public bool IsUserAuthenticated()
    {
        return PlayGamesPlatform.Instance.IsAuthenticated();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
