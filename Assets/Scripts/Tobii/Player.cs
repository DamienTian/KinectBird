using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] float sensativity = 0.01f;
    [SerializeField] bool isMainGame;
    [SerializeField] GazePosition gazePosition;

    // Start is called before the first frame update
    void Start()
    {
        isMainGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        // move forward
        transform.position += new Vector3(0f, 0f, movingSpeed * Time.deltaTime);
        // 
        transform.eulerAngles = new Vector3(Mathf.Lerp(transform.eulerAngles.x, gazePosition.disX, sensativity),
                                        Mathf.Lerp(transform.eulerAngles.y, gazePosition.disY, sensativity),
                                        transform.eulerAngles.z);

    }
}
