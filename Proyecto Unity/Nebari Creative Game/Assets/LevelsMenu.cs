using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelsMenu : MonoBehaviour
{
    public GameObject[] levels;
    private void Awake()
    {
        for(int i = 0; i < levels.Length; i++)
        {
            if (PlayerPrefs.HasKey((i + 1).ToString())){
                int numStars = PlayerPrefs.GetInt((i + 1).ToString());
                if(numStars == 1)
                {
                    GameObject star1 = levels[i].transform.Find("Stars_1").gameObject;
                    star1.GetComponent<Image>().color = new Color(230, 30, 87);
                }
                else if(numStars == 2)
                {
                    GameObject star1 = levels[i].transform.Find("Stars_1").gameObject;
                    star1.GetComponent<Image>().color = new Color(230, 30, 87);
                    GameObject star2 = levels[i].transform.Find("Stars_2").gameObject;
                    star2.GetComponent<Image>().color = new Color(230, 30, 87);
                }
                else if(numStars == 3)
                {
                    GameObject star1 = levels[i].transform.Find("Stars_1").gameObject;
                    star1.GetComponent<Image>().color = new Color(230, 30, 87);
                    GameObject star2 = levels[i].transform.Find("Stars_2").gameObject;
                    star2.GetComponent<Image>().color = new Color(230, 30, 87);
                    GameObject star3 = levels[i].transform.Find("Stars_3").gameObject;
                    star3.GetComponent<Image>().color = new Color(230, 30, 87);
                }
                Debug.Log("Nivel " + (i + 1).ToString() + ": Numero de estrellas " + numStars);
            }
        }
    }
    public void GoBack()
    {
        SceneManager.LoadScene("Menu_principal");
    }

    public void GoLevel1()
    {
        SceneManager.LoadScene("1");
    }
}
