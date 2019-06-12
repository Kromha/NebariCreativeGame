using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScript : MonoBehaviour
{
    public GameObject Ingame;
    public GameObject End;
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
            Destroy(GameObject.Find("Player"));
        }
    }
}
