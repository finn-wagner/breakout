using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static readonly float lightX = -15f;
    public static readonly float lightY = 8f;

    public static readonly string TAG = "Ball";

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("BottomWall"))
        {
            Death();
        }
    }

    private void FixedUpdate()
    {
        float currentX = transform.position.x;
        float currentY = transform.position.y;

        if (Mathf.Abs(currentX) > 17 || Mathf.Abs(currentY) > 9)
        {
            Death();
            return;
        }

        float distanceX = Mathf.Max(currentX, lightX) - Mathf.Min(currentX, lightX);
        float distanceY = Mathf.Max(currentY, lightY) - Mathf.Min(currentY, lightY);

        float degree = Mathf.Rad2Deg * Mathf.Atan(distanceX / distanceY);

        transform.rotation = Quaternion.AngleAxis(degree, Vector3.forward);

        float currentSpeed = Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2f) + Mathf.Pow(rb.velocity.y, 2f));

        Vector2 unitVector = new Vector2(rb.velocity.x / currentSpeed, rb.velocity.y / currentSpeed);
        Vector2 targetVector = Game.ballSpeed * unitVector;
        if (float.IsNaN(targetVector.x) || float.IsNaN(targetVector.y))
        {
            return;
        }
        rb.velocity = targetVector;
    }

    public void Reset()
    {
        transform.position = new Vector2(0f, -2f);
        rb.velocity = Vector2.zero;
    }

    private void Death()
    {
        Health health = FindObjectOfType<Health>();
        health.RemoveLife();

        gameObject.transform.position = new Vector2(0.0f, -2.0f);
    }
}
