using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathScript : MonoBehaviour
{
    public GameObject Ingame;
    public GameObject End;
    public Image star1;
    public Image star2;
    public Image star3;

    public void playLoseFX()
    {
        GameObject soundManager = GameObject.Find("SoundManager");
        if (soundManager != null)
        {
            soundManager.GetComponent<SoundManager>().playLose();
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Debug.Log("YOU LOSE!");

            playLoseFX();

            Ingame.SetActive(false);
            End.SetActive(true);
            GameObject.Find("Result").GetComponent<Text>().text = "YOU LOSE :(";
            Text score = GameObject.Find("ScoreNum").GetComponent<Text>();
            score.text = GameObject.Find("Player").GetComponent<PlayerController>().getPoints().ToString();
            Destroy(GameObject.Find("Player"));
            star1.color = new Color(155, 155, 155);
            star2.color = new Color(155, 155, 155);
            star3.color = new Color(155, 155, 155);
        }
    }
}
