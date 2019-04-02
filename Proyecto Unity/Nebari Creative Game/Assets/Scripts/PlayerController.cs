using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector2 initialSpeed;
    private Rigidbody2D rigid2D;

    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.velocity = initialSpeed;
        rigid2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rigid2D.velocity = speed * (rigid2D.velocity.normalized);
    }
}
