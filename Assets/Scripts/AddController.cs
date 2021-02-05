using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AddController : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3946106";
#elif UNITY_ANDROID
    private string gameId = "3946107";
#endif
    string myPlacementIdRewardedSecondChance = "rewardedVideo";
    string myPlacementIdRewardedLvlSuccess = "rewardedVideoLvlSuccess";
    string myPlacementIdBanner = "banner";
    bool testMode = false;

    private static AddController _instance;

    public static AddController Instance
    {
        get { return _instance; }
    }
    public int fails = 0;

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

    void Start()
    {
        // Initialize the Ads service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenInitialized());
    }
    public void ShowInterstitialAd()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
        }
        else
        {
            Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
        }
    }
    public void ShowRewardedVideo(string myPlacementIdRewarded)
    {
        if (myPlacementIdRewarded == "secondChance")
        {
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady(myPlacementIdRewardedSecondChance))
            {
                Advertisement.Show(myPlacementIdRewardedSecondChance);
            }
            else
            {
                Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
                FindObjectOfType<EndGame>().endPanel.SetActive(true);
            }
        }
        else if (myPlacementIdRewarded == "lvlSuccess")
        {
            // Check if UnityAds ready before calling Show method:
            if (Advertisement.IsReady(myPlacementIdRewardedLvlSuccess))
            {
                Advertisement.Show(myPlacementIdRewardedLvlSuccess);
            }
            else
            {
                Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
            }
        }
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            if (placementId == myPlacementIdRewardedSecondChance)
            {

                FindObjectOfType<SaveController>().save.coins -= 85;
                PlayerPrefs.SetInt(Save.COINS, FindObjectOfType<SaveController>().save.coins);

                if(FindObjectOfType<SaveController>().save.secondChance < 50)
                {
                    FindObjectOfType<SaveController>().save.secondChance++;
                    if (FindObjectOfType<SaveController>().save.secondChance == 50)
                    {
                        FindObjectOfType<PlayServices>().UnlockSecondChanceAchievement();
                    }
                    PlayerPrefs.SetInt(Save.SECOND_CHANCE, FindObjectOfType<SaveController>().save.secondChance);
                }
                FindObjectOfType<GameController>().RestartGameFromPoint();
            }
            else if (placementId == myPlacementIdRewardedLvlSuccess)
            {
                FindObjectOfType<GameController>().additionalCoins += 15;
                FindObjectOfType<GameController>().UpdateAdditionalCoins();
            }
            // Reward the user for watching the ad to completion.
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementIdRewardedSecondChance)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(myPlacementIdBanner);
    }
}
