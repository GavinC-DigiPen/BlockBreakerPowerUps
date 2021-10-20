//------------------------------------------------------------------------------
//
// File Name:	ScoreText.cs
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

public class ScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnScoreChange.AddListener(UpdateText);
        UpdateText();
    }

    // Update text
    public void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = " Score: " + GameManager.Score;
    }
}
