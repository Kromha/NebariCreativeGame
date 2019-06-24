using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerScript : MonoBehaviour
{
    public void goLevels()
    {
        playFX();
        SceneManager.LoadScene("Menu_niveles",LoadSceneMode.Single);
    }

    public void goExit()
    {
        playFX();
        Application.Quit();
    }

    public void changeToEasy()
    {
        GameObject.Find("Data").GetComponent<Datascript>().SetMode(0);

        Color notSelected;
        Color Selected; 
        ColorUtility.TryParseHtmlString("#E2E0D3", out notSelected);
        ColorUtility.TryParseHtmlString("#F29200", out Selected);

        GameObject.Find("EasyText").GetComponent<Text>().color = Selected;
        GameObject.Find("MediumText").GetComponent<Text>().color = notSelected;
        GameObject.Find("HardText").GetComponent<Text>().color = notSelected;

        playFX();
    }

    public void changeToMedium()
    {
        GameObject.Find("Data").GetComponent<Datascript>().SetMode(1);

        Color notSelected;
        Color Selected;
        ColorUtility.TryParseHtmlString("#E2E0D3", out notSelected);
        ColorUtility.TryParseHtmlString("#F29200", out Selected);

        GameObject.Find("EasyText").GetComponent<Text>().color = notSelected;
        GameObject.Find("MediumText").GetComponent<Text>().color = Selected;
        GameObject.Find("HardText").GetComponent<Text>().color = notSelected;

        playFX();
    }

    public void changeToHard()
    {
        GameObject.Find("Data").GetComponent<Datascript>().SetMode(2);

        Color notSelected;
        Color Selected;
        ColorUtility.TryParseHtmlString("#E2E0D3", out notSelected);
        ColorUtility.TryParseHtmlString("#F29200", out Selected);

        GameObject.Find("EasyText").GetComponent<Text>().color = notSelected;
        GameObject.Find("MediumText").GetComponent<Text>().color = notSelected;
        GameObject.Find("HardText").GetComponent<Text>().color = Selected;

        playFX();
    }

    public void playFX()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null)
        {
            soundManager.GetComponent<SoundManager>().playClickMenu();
        }
    }
}
