//-----------------------------------------------------------------------
// Copyright 2016 Tobii AB (publ). All rights reserved.
//-----------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

/// <summary>
/// Writes the position of the eye gaze point into a UI Text view
/// </summary>
/// <remarks>
/// Referenced by the Data View in the Eye Tracking Data example scene.
/// </remarks>
public class GazePosition : MonoBehaviour
{
	public GameObject GazePoint;
    public Text coordText;

    private float _pauseTimer;

    public float disX, disY;


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
            Vector2 roundedSampleInput = new Vector2(Mathf.RoundToInt(gazePosition.x), Mathf.RoundToInt(gazePosition.y));
            print(roundedSampleInput);
           // disX = roundedSampleInput.x - GameManager.Instance.center.x;
           // disY = roundedSampleInput.y - GameManager.Instance.center.y;
            coordText.text = "Dis to center X: " + disX + "       Dis to center Y: " + disY;
        }

		if (Input.GetKeyDown(KeyCode.Space) && gazePoint.IsRecent())
		{
			_pauseTimer = 3f;
            GazePoint.SetActive(true);
            GazePoint.transform.localPosition = (gazePoint.Screen - new Vector2(Screen.width, Screen.height) / 2f) / GetComponentInParent<Canvas>().scaleFactor;
		}
	}
}
