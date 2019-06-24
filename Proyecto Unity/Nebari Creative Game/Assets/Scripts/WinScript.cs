using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject Ingame;
    public GameObject End;
    private int numStars;
    private int maxpoints = 0;

    public Image star1;
    public Image star2;
    public Image star3;

    private void Awake()
    {
        //Points
        Pointable[] pointables = FindObjectsOfType<Pointable>();
        

        foreach (Pointable i in pointables)
        {
            maxpoints += i.getPoints();
        }
    }
    public void playWinFX()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null)
        {
            soundManager.GetComponent<SoundManager>().playWinFX();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("YOU WIN!");

            playWinFX();

            Ingame.SetActive(false);
            End.SetActive(true);
            GameObject.Find("Result").GetComponent<Text>().text = "YOU WIN!";
            Text score = GameObject.Find("ScoreNum").GetComponent<Text>();
            score.text = GameObject.Find("Player").GetComponent<PlayerController>().getPoints().ToString();
            numStars = 1;
            Destroy(GameObject.Find("Player"));

            GameObject dataObject = GameObject.Find("Data");

            if (dataObject != null)
            {
                Datascript data = GameObject.Find("Data").GetComponent<Datascript>();

                if (data != null && data.mode == Datascript.Mode.Hard)
                {
                    numStars++;
                }
            }

            Debug.Log("Maxpoints: " + maxpoints);

            if((float)(GameObject.Find("Player").GetComponent<PlayerController>().getPoints())/ (float)(maxpoints) > 0.75f)
            {
                numStars++;
            }

            Debug.Log("Percentage: " + (float)(GameObject.Find("Player").GetComponent<PlayerController>().getPoints()) / (float)(maxpoints));
            Debug.Log("Numstars: " + numStars);

            if (numStars == 1)
            {
                star1.color = new Color(255, 0, 0);
                star2.color = new Color(155, 155, 155);
                star3.color = new Color(155, 155, 155);
            }
            else if (numStars == 2)
            {
                star1.color = new Color(255, 0, 0);
                star2.color = new Color(255, 0, 0);
                star3.color = new Color(155, 155, 155);
            }
            else if (numStars == 3)
            {
                star1.color = new Color(255, 0, 0);
                star2.color = new Color(255, 0, 0);
                star3.color = new Color(255, 0, 0);
            }

            if (PlayerPrefs.HasKey(SceneManager.GetActiveScene().name))
            {
                if(numStars > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name))
                {
                    PlayerPrefs.DeleteKey(SceneManager.GetActiveScene().name);
                    PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, numStars);
                    PlayerPrefs.Save();
                }
            }
            else
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, numStars);
                PlayerPrefs.Save();
            }
           
        }
    }
}
