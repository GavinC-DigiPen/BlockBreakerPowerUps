//------------------------------------------------------------------------------
//
// File Name:	EndText.cs
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
using TMPro;

public class EndText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.Lives > 0)
        {
            GetComponent<TextMeshProUGUI>().text = "You Win";
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "You Lose";
        }
    }

}
