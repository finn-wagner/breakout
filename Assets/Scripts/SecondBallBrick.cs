using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBallBrick : MonoBehaviour
{

    public GameObject ballPrefab;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Ball.TAG) || collision.gameObject.tag.Equals(SecondBall.TAG))
        {
            Brick brick = GetComponent<Brick>();

            if (brick.lives == 0)
            {
                Instantiate(ballPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
