//------------------------------------------------------------------------------
//
// File Name:	HeartPowerUp.cs
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

public class HeartPowerUp : MonoBehaviour
{
    [Tooltip("Time before powerup can be picked up")]
    public float wakeTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        if (wakeTime > 0)
        {
            wakeTime -= Time.deltaTime;
        }
    }

    // Incease health when collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wakeTime <= 0)
        {
            GameManager.Lives++;
            Destroy(gameObject);
        }
    }
}
