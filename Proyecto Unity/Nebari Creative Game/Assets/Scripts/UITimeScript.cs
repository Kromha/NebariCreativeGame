using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITimeScript : MonoBehaviour
{
    public Text timer;
    public Button reset;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        timer.text = "0.0";
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        reset.onClick.AddListener(resetLevel);
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = gameManager.getActualTime().ToString("F1");
    }

    private void resetLevel()
    {
        Debug.Log("RESET BUTTON!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
}
