using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int maxLevels;
    
    private const int MENUSCENE = 0;
    private const int CUSTOMLINE = 1;
    private const int LEVELSELECTOR = 2;

    private void Start()
    {
        LineSizeChange.SetDefaultLine();
    }

    public void SelectMap(int map)
    {
        SceneManager.LoadScene("Map" + map);
    }

    public void SelectRandomMap()
    {
        int randomNum = Random.Range(3, maxLevels + 2);
        SceneManager.LoadScene(randomNum);
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
