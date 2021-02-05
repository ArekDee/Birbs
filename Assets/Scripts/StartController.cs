using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public GameObject startButtonsPanel;
    public GameObject creditsPanel;
    public GameObject optionsPanel;
    public GameObject challengesPanel;
    public GameObject messagePanel;
    public Slider musicSlider;
    public Slider effectsSlider;
    public AudioClip hitObstacle;
    public Text scoreText;
    public Text version;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<SaveController>().StartSaves();
        SetBestScoreText(FindObjectOfType<SaveController>().save.bestScore.ToString());
        version.text = Application.version;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetBestScoreText(string bestScore)
    {
        scoreText.text = bestScore; 
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void ShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }
    public void DefaultScreen()
    {
        messagePanel.SetActive(false);
        creditsPanel.SetActive(false);
        optionsPanel.SetActive(false);
        challengesPanel.SetActive(false);
        startButtonsPanel.SetActive(true);
    }
    public void DefaultScreenFromOptions()
    {
        MusicController.SaveMusicAndEffectVolume(musicSlider.value, effectsSlider.value / 2);
        optionsPanel.SetActive(false);
        startButtonsPanel.SetActive(true);
    }
    public void CreditsScreen()
    {
        startButtonsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }
    public void MessageScreen()
    {
        startButtonsPanel.SetActive(false);
        messagePanel.SetActive(true);
    }
    public void OptionsScreen()
    {
        musicSlider.value = MusicController.GetMusicVolume();
        effectsSlider.value = MusicController.GetEffectsVolume() * 2;
        startButtonsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }
    public void ChallengesScreen()
    {
        startButtonsPanel.SetActive(false);
        challengesPanel.SetActive(true);
    }
    public void OpenArekInsta()
    {
        Application.OpenURL("https://www.instagram.com/danny_a___/");
    }
    public void OpenDannyInsta()
    {
        Application.OpenURL("https://www.instagram.com/danny_games.pl/");
    }
    public void OpenKrzysInsta()
    {
        Application.OpenURL("https://www.instagram.com/dank_krzysiu/");
    }

    public void ChangeMusicVolume()
    {
        MusicController.ChangeMusicVolume(musicSlider.value);
    }
    public void AchievementButton_Click()
    {
        FindObjectOfType<PlayServices>().ShowAchievements();
    }
    public void LeaderboardButton_Click()
    {
        FindObjectOfType<PlayServices>().ShowLeaderboard();
    }



}
