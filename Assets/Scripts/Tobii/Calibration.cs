//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;
using UnityEngine.SceneManagement;

/// <summary>
/// Writes the position of the eye gaze point into a UI Text view
/// </summary>
/// <remarks>
/// Referenced by the Data View in the Eye Tracking Data example scene.
/// </remarks>
public class Calibration : MonoBehaviour
{
	public GameObject GazePoint;
    public Vector2 originCoord;

    private float _pauseTimer;


	void Start()
	{
        
    }

	void Update()
	{
		if (_pauseTimer > 0)
		{
			_pauseTimer -= Time.deltaTime;
			return;
		}

		GazePoint.SetActive(false);

		GazePoint gazePoint = TobiiAPI.GetGazePoint();
		if (gazePoint.IsValid)
		{
			Vector2 gazePosition = gazePoint.Screen;
            originCoord = new Vector2(Mathf.RoundToInt(gazePosition.x), Mathf.RoundToInt(gazePosition.y));
        }

		if (Input.GetKeyDown(KeyCode.Space))
		{
		}
	}
}
