using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int ballSpeed = 12;
    public static bool freeze = false;

    private int freezeTime = 300;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (freeze)
        {
            if (freezeTime == 300)
                ballSpeed = 8;

            freezeTime--;
            if (freezeTime <= 0)
            {
                ballSpeed = 12;
                freeze = false;
                freezeTime = 300;
            }
        }
    }
}
