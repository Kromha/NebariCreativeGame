using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public Vector2 initialSpeed;
    private Rigidbody2D rigid2D;
    public int objetosRecogidos = 0;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Recolectable"))
        {
            objetosRecogidos++;
            Destroy(collision.gameObject);
        }
    }
}
