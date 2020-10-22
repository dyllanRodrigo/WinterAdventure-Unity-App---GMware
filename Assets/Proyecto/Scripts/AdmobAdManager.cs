using UnityEngine;
using System.Collections;
using admob;

public class AdmobAdManager : MonoBehaviour {

    public static AdmobAdManager Instance{set;get;}

    public string bannerID;
    public string videoID;

    private void Start() {
        Instance = this;
        DontDestroyOnLoad(gameObject);

#if UNITY_EDITOR
#elif UNITY_ANDROID
        Admob.Instance().initAdmob(bannerID,videoID);
         Admob.Instance().setTesting(true);
        Admob.Instance().loadInterstitial();
#endif
    }


    public void ShowBanner() {
#if UNITY_EDITOR
        Debug.Log("Editor not supported");
#elif UNITY_ANDROID
        Admob.Instance().showBannerRelative(AdSize.Banner, AdPosition.BOTTOM_RIGHT,9);
#endif

    }

    public void ShowVideo() {
#if UNITY_EDITOR
#elif UNITY_ANDROID
        if (Admob.Instance().isInterstitialReady()) {
            Admob.Instance().showInterstitial();
    }
#endif
    }
}
