//------------------------------------------------------------------------------
//
// File Name:	Ball.cs
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

public class Ball : MonoBehaviour
{
    [Tooltip("Amount of x and y force added to ball on start")]
    public Vector2 forceAdded = new Vector2(250, 250);
    [Tooltip("The delay before the ball starts moving")]
    public float ballMoveDelay = 0.5f;
    [Tooltip("Amoung of damage the ball does (script)")]
    public int damage = 1;
    [Tooltip("Damage power up active time (script)")]
    public float damagePowerUpTimer = 0;

    private KeyCode moveBallKey = KeyCode.Space;
    private Color startingBallColor;
    private bool damageBoosted = false;

    // Start is called before the first frame update
    void Start()
    {
        startingBallColor = GetComponent<SpriteRenderer>().color;
        Invoke("DelayVelocity", ballMoveDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (damagePowerUpTimer > 0)
        {
            if (!damageBoosted)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                damage *= 2;
                damageBoosted = true;
            }

            damagePowerUpTimer -= Time.deltaTime;
        }
        else
        {
            if (damageBoosted)
            {
                GetComponent<SpriteRenderer>().color = startingBallColor;
                damage /= 2;
                damageBoosted = false;
                damagePowerUpTimer = 0;
            }
        }


        if (Input.GetKeyDown(moveBallKey))
        {
            DelayVelocity();
        }
    }

    // Coroutitine so delay can be added, adds velocity 
    private void DelayVelocity()
    {
        bool dirrection = Random.Range(0f, 1f) > 0.5f;
        if (dirrection)
        {
            forceAdded.x *= -1;
        }
        GetComponent<Rigidbody2D>().AddForce(forceAdded);
    }

    // Destroy when off screen
    private void OnBecameInvisible()
    {
        GameManager.Lives--;
        Destroy(gameObject);
    }
}
