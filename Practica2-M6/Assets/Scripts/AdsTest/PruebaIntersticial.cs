using UnityEngine;
using UnityEngine.Advertisements;

public class PruebaIntersticial : MonoBehaviour
{
    private string gameId = "4532005";
    private bool testMode = true;

    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }

    public void ShowIntersticialAd()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("Interstitial_Android");
        }
        else
        {
            Debug.Log("Intersticial ad not ready at the moment! Please try again later!");
        }
    }
}
