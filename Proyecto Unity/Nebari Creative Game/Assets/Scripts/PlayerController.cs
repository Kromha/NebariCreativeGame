using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {
        red,
        blue,
        orange
    }
    // Start is called before the first frame update
    public float speed;
    public Vector2 initialSpeed;
    public string redHexa;
    public string blueHexa;
    public string orangeHexa;
    public State state;


    private int objetosRecogidos = 0;
    private Rigidbody2D rigid2D;
    private Color redColor;
    private Color blueColor;
    private Color orangeColor;
    private Vector2 lastSpeed;
    private int points;
    private UITimeScript uITimeScript;


    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.velocity = initialSpeed;
        rigid2D.gravityScale = 0;

        redColor = new Color();
        blueColor = new Color();
        orangeColor = new Color();

        points = 0;
        uITimeScript = GameObject.Find("UIManager").GetComponent<UITimeScript>();

        ColorUtility.TryParseHtmlString(redHexa, out redColor);
        ColorUtility.TryParseHtmlString(blueHexa, out blueColor);
        ColorUtility.TryParseHtmlString(orangeHexa, out orangeColor);

        switch (state)
        {
            case State.red:
                this.gameObject.GetComponent<SpriteRenderer>().color = redColor;
                break;
            case State.blue:
                this.gameObject.GetComponent<SpriteRenderer>().color = blueColor;
                break;
            case State.orange:
                this.gameObject.GetComponent<SpriteRenderer>().color = orangeColor;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rigid2D.velocity = speed * (rigid2D.velocity.normalized);
        lastSpeed = rigid2D.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Recolectable"))
        {
            objetosRecogidos++;
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("OrangeP"))
        {
            state = State.orange;
            this.gameObject.GetComponent<SpriteRenderer>().color = orangeColor;
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("RedP"))
        {
            state = State.red;
            this.gameObject.GetComponent<SpriteRenderer>().color = redColor;
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
        }
        else if (collision.name.Contains("BlueP"))
        {
            state = State.blue;
            this.gameObject.GetComponent<SpriteRenderer>().color = blueColor;
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name.Contains("OrangeO") && state.Equals(State.orange))
        {
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
            rigid2D.velocity = lastSpeed;
        }
        else if (collision.collider.name.Contains("RedO") && state.Equals(State.red))
        {
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
            rigid2D.velocity = lastSpeed;
        }
        else if (collision.collider.name.Contains("BlueO") && state.Equals(State.blue))
        {
            addPoints(collision.gameObject);
            Destroy(collision.gameObject);
            rigid2D.velocity = lastSpeed;
        }
    }

    private void addPoints(GameObject go)
    {
        Pointable pointable = go.GetComponent<Pointable>();

        if (pointable != null)
        {
            points += pointable.getPoints();
            uITimeScript.setPoints(points);
        }
    }
}
