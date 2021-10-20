//------------------------------------------------------------------------------
//
// File Name:	GameManager.cs
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
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    private static int score = 0;
    private static int lives = 3;

    public static UnityEvent OnScoreChange = new UnityEvent();
    public static UnityEvent OnLivesChange = new UnityEvent();

    public static int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            OnScoreChange.Invoke();
        }
    }

    public static int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
            OnLivesChange.Invoke();
        }
    }
}
