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
    [Tooltip("Starting velocity of the ball")]
    public float startingVelocity = 8;
    [Tooltip("Max velocity on ball")]
    public float maxVelocity = 7;
    [Tooltip("The delay before the ball starts moving")]
    public float ballMoveDelay = 0.5f;
    [Tooltip("Color the ball is when it has the damage powerup")]
    public Color damagePowerUpColor;
    [Tooltip("Amoung of damage the ball does (script)")]
    public int damage = 1;
    [Tooltip("Damage power up active time (script)")]
    public float damagePowerUpTimer = 0;
    [Tooltip("Size power up active time (script)")]
    public float sizePowerUpTimer = 0;

    private Rigidbody2D ballRB;
    private SpriteRenderer ballSP;
    private KeyCode moveBallKey = KeyCode.Space;

    private Color startingBallColor;
    private bool damageBoosted = false;
    private Vector3 startingBallSize;
    private bool sizeBoosted = false;


    // Start is called before the first frame update
    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        ballSP = GetComponent<SpriteRenderer>();
        startingBallColor = ballSP.color;
        startingBallSize = transform.localScale;

        float rotation = 0;
        while (rotation == 0)
        {
            rotation = Random.Range(-6, 6) * 12.5f;
        }
        transform.Rotate(0, 0, rotation, Space.Self);
        ballRB = GetComponent<Rigidbody2D>();
        Invoke("DelayVelocity", ballMoveDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // PowerUps
        if (damagePowerUpTimer > 0)
        {
            if (!damageBoosted)
            {
                ballSP.color = damagePowerUpColor;
                damage *= 2;
                damageBoosted = true;
            }

            damagePowerUpTimer -= Time.deltaTime;
        }
        else
        {
            if (damageBoosted)
            {
                ballSP.color = startingBallColor;
                damage /= 2;
                damageBoosted = false;
                damagePowerUpTimer = 0;
            }
        }

        if (sizePowerUpTimer > 0)
        {
            if (!sizeBoosted)
            {
                transform.localScale = startingBallSize * 2;
                sizeBoosted = true;
            }

            sizePowerUpTimer -= Time.deltaTime;
        }
        else
        {
            if (sizeBoosted)
            {
                transform.localScale = startingBallSize;
                sizeBoosted = false;
                sizePowerUpTimer = 0;
            }
        }

        // "Fix" ball velocity 
        if (Input.GetKeyDown(moveBallKey))
        {
            DelayVelocity();
        }

        ballRB.velocity = Vector2.ClampMagnitude(ballRB.velocity, maxVelocity);
    }

    // Coroutitine so delay can be added, adds velocity 
    private void DelayVelocity()
    {
        ballRB.velocity = transform.up * startingVelocity;
    }

    // Destroy when off screen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
