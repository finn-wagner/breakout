using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{

    public GameObject winPrefab;

    private static int points = 0;

    static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;

        if (points == 36)
        {
            Canvas canvas = FindObjectOfType<Canvas>();

            GameObject tempLoseText = Instantiate(winPrefab, new Vector2(0f, 0f), Quaternion.identity);
            tempLoseText.transform.SetParent(canvas.transform, false);

            Ball ball = FindObjectOfType<Ball>();
            Destroy(ball.gameObject);

            SecondBall[] secondBalls = FindObjectsOfType<SecondBall>();

            foreach (SecondBall secondBall in secondBalls)
            {
                Destroy(secondBall.gameObject);
            }
        }

        UpdateGUI();
    }

    public static void Reset()
    {
        points = 0;
        UpdateGUI();
    }

    private static void UpdateGUI()
    {
        text.text = "Punkte: " + points;
    }
}
