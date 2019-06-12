using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datascript : MonoBehaviour
{
    public static Datascript Instance;
    public enum Mode { Easy, Medium, Hard};
    public Mode mode = Mode.Medium;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetMode(int i)
    {
        switch (i)
        {
            case 0:
                mode = Mode.Easy;
                break;
            case 1:
                mode = Mode.Medium;
                break;
            case 2:
                mode = Mode.Hard;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
