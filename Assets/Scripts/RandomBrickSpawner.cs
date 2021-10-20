//------------------------------------------------------------------------------
//
// File Name:	RandomBrickSpawner.cs
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

public class RandomBrickSpawner : MonoBehaviour
{
    [Tooltip("The brick prefab")]
    public GameObject brickPrefab;
    [Tooltip("Delay range between brick spawns")]
    public Vector2 spawnDelay = new Vector2 (2, 4);
    [Tooltip("The position of the top left most block spawn location")]
    public Vector2 topLeft = new Vector2(-8f, 4.5f);
    [Tooltip("The position of the bottom right most block spawn location")]
    public Vector2 bottomRight = new Vector2(8f, -4.5f);

    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(spawnDelay.x, spawnDelay.y);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Vector2 spawnLocation;
            spawnLocation.x = Random.Range(topLeft.x, bottomRight.x);
            spawnLocation.y = Random.Range(topLeft.y, bottomRight.y);
            Instantiate(brickPrefab, spawnLocation, Quaternion.identity);
            timer = Random.Range(spawnDelay.x, spawnDelay.y);
        }
    }
}
