using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
using UnityEngine.UI;

public class AdmanagerGame : MonoBehaviour
{

    private MainMenu main;
    public GameObject rewardedButton;
    void Start()
    {
        main = FindObjectOfType<MainMenu>();
    }

    void Update()
    {

        if (Advertisement.IsReady("rewardedVideo"))
        {
            rewardedButton.SetActive(true);
        }
        else
        {
            rewardedButton.SetActive(false);
        }
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                main.AgregarVidas(2);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}