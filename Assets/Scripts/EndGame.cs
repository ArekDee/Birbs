using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class EndGame : MonoBehaviour
{
    public GameObject endPanel;
    public GameObject secondChancePanel;
    public GameObject background;
    public Animator secondChanceAnimator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            FindObjectOfType<spawnObstacles>().spawn = false;
            FindObjectOfType<spawnMisteries>().spawn = false;
            background.GetComponent<AutoMoveAndRotate>().enabled = false;

            //Ads
            FindObjectOfType<AddController>().fails++;
            if (FindObjectOfType<AddController>().fails == 4)
            {
                FindObjectOfType<AddController>().fails = 0;
                FindObjectOfType<AddController>().ShowInterstitialAd();
            }

            if (FindObjectOfType<GameController>().GetSecondChance() && FindObjectOfType<GameController>().score >= 5)
            {
                FindObjectOfType<GameController>().SetSecondChance();
                StartCoroutine(SecondChanceCounter());
            }
            else
            {
                OpenEndPanel();
            }
        }
    }

    IEnumerator SecondChanceCounter()
    {
        secondChancePanel.SetActive(true);
        secondChanceAnimator.SetTrigger("Lose");
        yield return new WaitForSeconds(2.45f);
        if (secondChancePanel.active)
        {
            secondChancePanel.SetActive(false);
            OpenEndPanel();
        }
    }

    public void SecondChanceGame()
    {
        if(FindObjectOfType<SaveController>().save.coins >= 85)
        {
            secondChancePanel.SetActive(false);
            FindObjectOfType<AddController>().ShowRewardedVideo("secondChance");
        }
    }

    public void OpenEndPanel()
    {
        endPanel.transform.GetChild(0).GetComponent<Text>().text = "+" + (FindObjectOfType<GameController>().score + FindObjectOfType<GameController>().additionalCoins).ToString() + "$";
        FindObjectOfType<GameController>().AddScoreToLeaderboard();

        if (FindObjectOfType<SaveController>().save.ornithologistExpert < 1000)
        {
            FindObjectOfType<SaveController>().save.ornithologistExpert++;

            if (FindObjectOfType<SaveController>().save.ornithologistExpert == 100)
            {
                FindObjectOfType<PlayServices>().UnlockOrnitchologistAchievement();
            }
            else if (FindObjectOfType<SaveController>().save.ornithologistExpert == 1000)
            {
                FindObjectOfType<PlayServices>().UnlockExpertAchievement();
            }
            PlayerPrefs.SetInt(Save.ORNITHOLOGIST_AND_EXPERT, FindObjectOfType<SaveController>().save.ornithologistExpert);
        }

        FindObjectOfType<GameController>().SetActiveBestScore();
        endPanel.SetActive(true);
    }
}
