using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBall : MonoBehaviour
{
    public static readonly float lightX = -15f;
    public static readonly float lightY = 8f;

    public static readonly string TAG = "SecondBall";

    private Rigidbody2D rb;

    private int timeToLive = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void FixedUpdate()
    {
        timeToLive--;
        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }

        float currentX = transform.position.x;
        float currentY = transform.position.y;

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
}

