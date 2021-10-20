//------------------------------------------------------------------------------
//
// File Name:	ChangeScene.cs
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

public class ChangeScene : MonoBehaviour
{
    [Tooltip("The name of the scene that should be loaded")]
    public string sceneToLoad;

    // Changes the scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
