using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour {

    public Transform target; //Target to follow
    public float speed; //Speed of camera movement
    public float minX; //Minimum X position of camera
    public float maxX; //Maximum X position of camera
    public float minY; //Minimum Y position of camera
    public float maxY; //Maximum Y position of camera

    private void Start()
    {
        //Set camera position to target position
        transform.position = target.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            float clampedX = Mathf.Clamp(target.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(target.position.y, minY, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
    }


}