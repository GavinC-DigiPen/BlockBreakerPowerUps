//------------------------------------------------------------------------------
//
// File Name:	Brick.cs
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

public class Brick : MonoBehaviour
{
    [Tooltip("The name of the scene that will be loaded when all bricks broken")]
    public string endScene = "EndScreen";
    [Tooltip("Do these bricks give score, when all destroyed does it move to new scene")]
    public bool scoring = true;
    [Tooltip("An array of powerUps to summon on brick death")]
    public GameObject[] powerUps;
    [Tooltip("Change of powerup spawning")]
    public int powerUpSpawnChance = 5;

    private Vector2 healthRange = new Vector2(1, 3);
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = Random.Range((int)healthRange.x, (int)healthRange.y + 1);

        switch (health)
        {
            case 1:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 3:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }
    }

    // Decrease health when collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ballScript = collision.gameObject.GetComponent<Ball>();
        if (ballScript)
        {
            health -= ballScript.damage;
            if (health <= 0)
            {
                if (scoring)
                {
                    GameManager.Score++;

                    Brick[] numberOfBricks = FindObjectsOfType<Brick>();
                    if (numberOfBricks.Length <= 1)
                    {
                        SceneManager.LoadScene(endScene);
                    }
                }

                if (powerUps.Length > 0)
                {
                    if (Random.Range(0, 100) <= powerUpSpawnChance)
                    {
                        Instantiate(powerUps[Random.Range(0, powerUps.Length)], transform.position, Quaternion.identity);
                    }
                }

                Destroy(gameObject);
            }
            else
            {
                switch (health)
                {
                    case 1:
                        GetComponent<SpriteRenderer>().color = Color.red;
                        break;
                    case 2:
                        GetComponent<SpriteRenderer>().color = Color.yellow;
                        break;
                    case 3:
                        GetComponent<SpriteRenderer>().color = Color.green;
                        break;
                }
            }
        }
    }
}
