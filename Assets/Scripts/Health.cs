using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Health : MonoBehaviour
{

    public GameObject losePrefab;
    private static int lives = 5;

    static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "Leben: " + lives;
    }

    public void RemoveLife()
    {
        if (lives == 0)
        {

            Canvas canvas = FindObjectOfType<Canvas>();

            GameObject tempLoseText = Instantiate(losePrefab, new Vector2(0f, 0f), Quaternion.identity);
            tempLoseText.transform.SetParent(canvas.transform, false);

            Ball ball = FindObjectOfType<Ball>();
            Destroy(ball.gameObject);

            SecondBall[] secondBalls = FindObjectsOfType<SecondBall>();

            foreach (SecondBall secondBall in secondBalls)
            {
                Destroy(secondBall.gameObject);
            }
        } else
        {
            lives--;
        }
        UpdateGUI();
    }

    public static void Reset()
    {
        lives = 5;

        UpdateGUI();
    }

    private static void UpdateGUI()
    {
        text.text = "Leben: " + lives;
    }
}
