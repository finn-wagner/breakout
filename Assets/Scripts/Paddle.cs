using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDrag()
    {
        Vector2 touchPosition = Input.mousePosition;
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        rb.MovePosition(new Vector2(worldPosition.x, transform.position.y));
    }

    public void Reset()
    {
        transform.position = new Vector2(0f, -7f);
    }
}
