using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public bool isStart;
    public Bird bird;
    public GameObject cameraHolder;
    public GameObject bodyView;
    public TubeSpanwer tubeSpanwer;

    public BodySourceView bodySourceView;

    #region parameters
    // applied to both camera and bird
    public float movingSpeed = 1f;
    public float handDetectRate = 0.16f;
    public float handDetectRateCounter;

    public float previousLeftY, previousRightY;
    public float changingYRange = 0.1f;

    public float flyCD = 0.2f;
    public float previousFly;
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        isStart = false;
        bird.lookHead.GetComponent<Rigidbody>().isKinematic = true;
        tubeSpanwer.enabled = false;
        handDetectRateCounter = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isStart)
        {
            bird.lookHead.GetComponent<Rigidbody>().isKinematic = false;
            tubeSpanwer.enabled = true;
            isStart = true;
            previousLeftY = bodySourceView.handLeft.Position.Y;
            previousRightY = bodySourceView.handRight.Position.Y;
        }

        if (isStart)
        {
            bird.transform.Translate(movingSpeed, 0, 0);
            cameraHolder.transform.Translate(movingSpeed, 0, 0);
            tubeSpanwer.transform.Translate(movingSpeed, 0, 0);
            bodyView.transform.Translate(movingSpeed, 0, 0);

            if (handDetectRateCounter >= handDetectRate)
            {

                float leftY =  bodySourceView.handLeft.Position.Y;
                float rightY = bodySourceView.handRight.Position.Y;

                if(Mathf.Abs(leftY - previousLeftY) > changingYRange &&
                   Mathf.Abs(rightY - previousRightY) > changingYRange)
                {
                    
                    
                    if(Time.time - previousFly > flyCD)
                    {
                        bird.Fly(bird.flyForce);
                        previousFly = Time.time;
                        print("Time.time: " + Time.time);
                    }                    

                }

                previousLeftY = leftY;
                previousRightY = rightY;
                handDetectRateCounter = 0;
            }

            handDetectRateCounter += Time.deltaTime;
        }

        
    }
}
