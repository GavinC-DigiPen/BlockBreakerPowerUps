//------------------------------------------------------------------------------
//
// File Name:	BallSizePowerUp.cs
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

public class BallSizePowerUp : MonoBehaviour
{
    [Tooltip("The time the size bonus will be active")]
    public float powerUpTime = 2.5f;
    [Tooltip("Time before powerup can be picked up")]
    public float wakeTime = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if (wakeTime > 0)
        {
            wakeTime -= Time.deltaTime;
        }
    }

    // Incease ball damage when collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (wakeTime <= 0)
        {
            Ball ballScript = collision.gameObject.GetComponent<Ball>();
            if (ballScript)
            {
                ballScript.sizePowerUpTimer += powerUpTime;
                Destroy(gameObject);
            }
        }
    }
}
