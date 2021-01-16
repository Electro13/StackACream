using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float targetPosition;
    public float speed;


    // Update is called once per frame
    void Update()
    {
        //Linear interpolation to move camera to position
        if(transform.position.y < targetPosition)
        {
            float y = Mathf.Lerp(targetPosition, transform.position.y, speed);

            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }
    }
}
