using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBrick : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(Ball.TAG) || collision.gameObject.tag.Equals(SecondBall.TAG))
        {
            Brick brick = GetComponent<Brick>();

            if (brick.lives == 0)
            {
                ExplosionDetection(transform.position, 2f);
            }
        }
    }

    void ExplosionDetection(Vector2 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.attachedRigidbody.gameObject.tag != Ball.TAG)
            {
                Destroy(hitCollider.attachedRigidbody.gameObject);
            }
        }
    }
}
