//------------------------------------------------------------------------------
//
// File Name:	LevelController.cs
// Author(s):	Gavin Cooper (gavin.cooper@digipen.edu)
// Project:	    BlockBreakerPowerUps
// Course:	    WANIC VGP2
//
// Copyright © 2021 DigiPen (USA) Corporation.
//
//------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [Tooltip("The starting amount of lives")]
    public int startingLives = 3;
    [Tooltip("The bottom left corner for area bricks will be spawned in")]
    public Vector2 oppositeCorner;
    [Tooltip("The offset of the second layer")]
    public float secondLayerOffset = 0.625f;
    [Tooltip("The regular offset between bricks")]
    public Vector2 spacing = new Vector2(1.25f, 0.5f);
    [Tooltip("The brick prefab")]
    public GameObject brickPrefab;
    [Tooltip("Prefab of the ball")]
    public GameObject ball;
    [Tooltip("The scene that will be loaded when all the bricks are destroyed")]
    public string sceneToLoad;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Score = 0;
        GameManager.Lives = startingLives;

        Vector3 spawnLocation = transform.position;

        spawnLocation.y = transform.position.y;
        for (int y = 0; spawnLocation.y > oppositeCorner.y; y++)
        {
            if (y % 2 == 0)
            {
                spawnLocation.x = transform.position.x;
            }
            else
            {
                spawnLocation.x = transform.position.x + secondLayerOffset;
            }
            while (spawnLocation.x < oppositeCorner.x)
            {
                Instantiate(brickPrefab, spawnLocation, Quaternion.identity);
                spawnLocation.x += spacing.x;
            }
            spawnLocation.y -= spacing.y;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ball[] balls = FindObjectsOfType<Ball>();
        if (balls.Length <= 0)
        {
            Instantiate(ball);
        }

        Brick[] bricks = FindObjectsOfType<Brick>();
        if (bricks.Length <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        if (GameManager.Lives <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
