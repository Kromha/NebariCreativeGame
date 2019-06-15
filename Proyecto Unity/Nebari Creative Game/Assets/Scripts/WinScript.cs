using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("YOU WIN!");

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

           
        }
    }
}
