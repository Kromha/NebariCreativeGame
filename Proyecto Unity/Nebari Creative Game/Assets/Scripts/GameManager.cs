using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float actualTime;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = 0.0f;    
    }

    // Update is called once per frame
    void Update()
    {
        actualTime += Time.deltaTime;
        Debug.Log(actualTime);
    }

    public float getActualTime()
    {
        return actualTime;
    }
}
