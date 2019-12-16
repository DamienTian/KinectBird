using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] float movingSpeed = 5f;
    [SerializeField] bool isMainGame;

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
    }
}
