using UnityEngine;
using UnityEngine.Advertisements;

namespace Managers
{
    public class AdsManager : MonoBehaviour
    {

        public void ShowRewardedAd()
        {

            Debug.Log("Showing ad..");
            if (Advertisement.IsReady("rewardedVideo"))
            {
                Debug.Log("Ad is ready!");
                var options = new ShowOptions
                {
                    resultCallback = HandleShowResult
                };
                Advertisement.Show("rewardedVideo", options);
            }
        }

        private void HandleShowResult(ShowResult result)
        {
            Debug.Log("Handling ad results...");
            switch (result)
            {
                case ShowResult.Finished:
                    Debug.Log("Reborn");
                    ScoreManager.Instance.adWatched = true;
                    StartCoroutine(GameManager.Instance.WaitOneSec(2));
                    break;
                case ShowResult.Skipped:
                    Debug.Log("No reward got! Video was skipped!");
                    break;
                case ShowResult.Failed:
                    Debug.Log("No reward got! Video failed(");
                    break;

            }
        }
    }
}
