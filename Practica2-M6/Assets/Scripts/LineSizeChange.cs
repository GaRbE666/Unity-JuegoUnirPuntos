using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineSizeChange : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRender;
    [SerializeField] private Material[] materials;

    private const string SAVEDCOLOR = "color";
    private const string SAVEDSIZE = "size";

    public void ChangeLineSize(float value)
    {
        lineRender.startWidth = value;
        lineRender.endWidth = value;
        PlayerPrefs.SetFloat(SAVEDSIZE, value);
    }

    public void ChangeLineColorDynamic(string color)
    {
        switch (color)
        {
            case "Red":
                lineRender.material = materials[0];
                PlayerPrefs.SetInt(SAVEDCOLOR, 0);
                break;
            case "Yellow":
                lineRender.material = materials[1];
                PlayerPrefs.SetInt(SAVEDCOLOR, 1);
                break;
            case "Black":
                lineRender.material = materials[2];
                PlayerPrefs.SetInt(SAVEDCOLOR, 2);
                break;
            case "Green":
                lineRender.material = materials[3];
                PlayerPrefs.SetInt(SAVEDCOLOR, 3);
                break;
            case "Blue":
                lineRender.material = materials[4];
                PlayerPrefs.SetInt(SAVEDCOLOR, 4);
                break;
            case "Purple":
                lineRender.material = materials[5];
                PlayerPrefs.SetInt(SAVEDCOLOR, 5);
                break;
            case "Pink":
                lineRender.material = materials[6];
                PlayerPrefs.SetInt(SAVEDCOLOR, 6);
                break;
            case "Orange":
                lineRender.material = materials[7];
                PlayerPrefs.SetInt(SAVEDCOLOR, 7);
                break;
            default:
                lineRender.material = materials[0];
                PlayerPrefs.SetInt(SAVEDCOLOR, 0);
                break;
        }

    }

}
