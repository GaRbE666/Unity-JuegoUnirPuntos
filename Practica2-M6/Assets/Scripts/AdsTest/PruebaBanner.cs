using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class PruebaBanner : MonoBehaviour
{
    private string gameId = "4532005";
    private string surficingId = "Banner_Android";
    private bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenInitialized());
    }

    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(surficingId);
    }
}
