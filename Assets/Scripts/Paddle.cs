//------------------------------------------------------------------------------
//
// File Name:	Paddle.cs
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

public class Paddle : MonoBehaviour
{
    [Tooltip("Speed of paddle")]
    public float speed = 10;
    [Tooltip("The max and min x for the paddle")]
    public float XManMix;
    [Tooltip("Size power up active time (script)")]
    public float sizePowerUpTimer = 0;

    private Rigidbody2D paddleRB;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;

    private Vector3 startingPaddleSize;
    private bool sizeBoosted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleRB = GetComponent<Rigidbody2D>();

        startingPaddleSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Get dirrection
        int dirrection = 0;
        if (Input.GetKeyDown(leftKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = -1;
        }
        else if (Input.GetKeyDown(rightKey))
        {
            dirrection = 1;
        }
        else if (Input.GetKey(rightKey) && !Input.GetKey(leftKey))
        {
            dirrection = 1;
        }
        else if (!Input.GetKey(leftKey) && !Input.GetKey(rightKey))
        {
            dirrection = 0;
        }

        // Add force  
        paddleRB.velocity = new Vector2(dirrection * speed, 0);
        if (transform.position.x >= XManMix)
        {
            transform.position = new Vector2(XManMix, transform.position.y);

        }
        else if (transform.position.x <= -XManMix)
        {
            transform.position = new Vector2(-XManMix, transform.position.y);
        }

        // PowerUp
        if (sizePowerUpTimer > 0)
        {
            if (!sizeBoosted)
            {
                transform.localScale = startingPaddleSize * 2;
                sizeBoosted = true;
            }

            sizePowerUpTimer -= Time.deltaTime;
        }
        else
        {
            if (sizeBoosted)
            {
                transform.localScale = startingPaddleSize;
                sizeBoosted = false;
                sizePowerUpTimer = 0;
            }
        }
    }
}
