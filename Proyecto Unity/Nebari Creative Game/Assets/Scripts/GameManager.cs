using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private float actualTime;
    private float auxTime;
    private bool active;
    private bool go;
    private bool waiting;
    private Transform initialPoint;
    private Vector2 directionVector;
    private Vector3 newPosition;
    private Vector3 lastPosition;

    public CinemachineVirtualCamera auxCamera;
    public Transform cameraTransform;
    public Transform finalPoint;
    public Vector2 playerSpeed;
    public float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = 0.0f;
        InitializeAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        //Normal loop
        if (active)
        {
            actualTime += Time.deltaTime;
        }
        //Initialize loop
        else
        {
            if (!waiting)
            {
                //Player to winzone
                if (go)
                {
                    if (lastPosition.x == newPosition.x && lastPosition.y == newPosition.y)
                    {
                        auxTime += Time.deltaTime;

                        if (auxTime > 0.1f)
                        {
                            comeBack();
                        }
                    }
                    else
                    {
                        auxTime = 0.0f;
                    }
                    lastPosition = newPosition;
                    auxCamera.transform.Translate(new Vector3(directionVector.x, directionVector.y, 0) * speed);
                    newPosition = cameraTransform.position;

                }
                //Winzone to player
                else
                {
                    if (lastPosition.x == newPosition.x && lastPosition.y == newPosition.y)
                    {
                        auxTime += Time.deltaTime;

                        if (auxTime > 0.5f)
                        {
                            InitializeCameraPlayer();
                        }
                    }
                    else
                    {
                        auxTime = 0.0f;
                    }
                    lastPosition = newPosition;
                    auxCamera.transform.Translate(new Vector3(directionVector.x, directionVector.y, 0) * speed);
                    newPosition = newPosition = cameraTransform.position;

                }
            }
            else
            {
                auxTime += Time.deltaTime;
                if(auxTime > 2.0f)
                {
                    InitializePlayer();
                }
            }
        }
    }

    public float getActualTime()
    {
        return actualTime;
    }

    public void InitializeAnimation()
    {
        //Initialize
        auxTime = 0.0f;
        active = false;
        go = true;
        waiting = false;
        initialPoint = auxCamera.Follow.transform;
        auxCamera.Follow = null;
        directionVector = new Vector2(finalPoint.position.x - initialPoint.position.x, finalPoint.position.y - initialPoint.position.y);
        directionVector = directionVector.normalized;
        auxCamera.Priority = 20;
        lastPosition = new Vector3(100, 100, 100);
        newPosition = new Vector3(-50, 10, 34);
    }

    public void InitializePlayer()
    {
        //Initialize player
        active = true;
        waiting = false;
        GameObject.Find("Player").GetComponent<PlayerController>().GetRigidbody2D().velocity = playerSpeed;
    }

    public void InitializeCameraPlayer()
    {
        //Initialize camera player
        waiting = true;
        auxCamera.Priority = 5;
        auxTime = 0.0f;
    }

    public void comeBack()
    {
        go = false;
        directionVector = new Vector2(initialPoint.position.x - finalPoint.position.x, initialPoint.position.y - finalPoint.position.y);
        directionVector = directionVector.normalized;
        lastPosition = new Vector3(100, 100, 100);
        newPosition = new Vector3(-50, 10, 34);
        auxTime = 0.0f;
    }
}
