using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{

    public GameObject brickPrefab;
    public GameObject specialBrick1Prefab;
    public GameObject specialBrick2Prefab;
    public GameObject specialBrick3Prefab;
    public GameObject specialBrick4Prefab;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBricks();
    }

    private void SpawnBrick(int type, float x, float y)
    {
        switch (type)
        {
            case 0:
                Instantiate(specialBrick1Prefab, new Vector2(x, y), Quaternion.identity);
                break;
            case 1:
                Instantiate(specialBrick2Prefab, new Vector2(x, y), Quaternion.identity);
                break;
            case 2:
                Instantiate(specialBrick3Prefab, new Vector2(x, y), Quaternion.identity);
                break;
            case 3:
                Instantiate(specialBrick4Prefab, new Vector2(x, y), Quaternion.identity);
                break;
            default:
                Instantiate(brickPrefab, new Vector2(x, y), Quaternion.identity);
                break;
        }
    }

    public void GenerateBricks()
    {
        for (int n = 0; n < 4; n++)
        {
            for (int i = 0; i < 5; i++)
            {
                int type = Random.Range(0, 15);

                SpawnBrick(type, i * 2.75f, n * 2f);
                if (i != 0)
                {
                    SpawnBrick(type, -i * 2.75f, n * 2f);
                }
            }
        }

        Points.Reset();
        Health.Reset();
    }

    public void ResetBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        foreach (GameObject brick in bricks)
        {
            DestroyImmediate(brick);
        }
    }
}
