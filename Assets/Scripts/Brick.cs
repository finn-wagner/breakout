using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int lives = 3;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Ball.TAG) || collision.gameObject.tag.Equals(SecondBall.TAG))
        {
            lives--;
            if (lives == 1)
            {
                animator.SetTrigger("break");
            }
            if (lives == 0)
            {
                animator.SetTrigger("destroy");
                Destroy(gameObject, 1);
            }
        }
    }

    private void OnDestroy()
    {
        Points points = FindObjectOfType<Points>();
        if (points != null)
        {
            points.AddPoints(1);
        }
    }
}
