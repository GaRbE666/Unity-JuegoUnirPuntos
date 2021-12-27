using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int maxLevels;
    
    //private static MenuManager menuManager;
    private const int MENUSCENE = 0;
    private const int CUSTOMLINE = 1;
    private const int LEVELSELECTOR = 2;

    //private void Awake()
    //{
    //    if (menuManager != null && menuManager != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        menuManager = this;
    //    }

    //    DontDestroyOnLoad(gameObject);
    //}

    public void SelectRandomMap()
    {
        int randomNum = Random.Range(3, maxLevels + 2);
        SceneManager.LoadScene(randomNum);
        Debug.Log(randomNum);
    }

    public void CustomizeLine()
    {
        SceneManager.LoadScene(CUSTOMLINE);
    }

    public void ExitGame()
    {
        Application.Quit(0);
    }

    public void SelectMap()
    {
        SceneManager.LoadScene(LEVELSELECTOR);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(MENUSCENE);
    }
}
