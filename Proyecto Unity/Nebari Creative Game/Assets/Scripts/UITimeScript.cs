using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimeScript : MonoBehaviour
{
    public Text timer;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "0.0";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = gameManager.getActualTime().ToString("F1");
    }
}
