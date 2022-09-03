using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera : MonoBehaviour
{
    public Transform target;

    public float camSpeed= 0.125f; // should be 0-1, the higher the faster cam locks on to target
    public Vector3 offset; // vector 3 to help it with all 3 axes
    
    public BoxCollider2D bounds;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    private Camera cam;
    private float halfHeight;
    private float halfWidth;

    //void Awake(){

    //}

    // Start is called before the first frame update
    void Start()
    {
        // where map is
        minBounds = bounds.bounds.min;
        maxBounds = bounds.bounds.max;

        // below code is used to restrict camera 
        cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void LateUpdate () { // says that player's update goes first, then camera
        // define desired position
        Vector3 desiredPosition = target.position + offset;
        // cam shimmies on over to the position, delta time says nice smoothing no matter the fps
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camSpeed);
        transform.position = smoothedPosition;
        // lerp is lin interpretation, smoothly go from point A to point B
        // lerp is Lerp(starting point, desired position, time (value from 0-1))
        // set below to desiredPosition for no smoothing
        //transform.position = desiredPosition; // setting camera position to the target's position

        // below code is used to restrict camera
        // clamp says heres a max and min value, now we make sure the value we have is between them
        float clampx = Mathf.Clamp(transform.position.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        float clampy = Mathf.Clamp(transform.position.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        transform.position = new Vector3(clampx, clampy, transform.position.z);


    }   
}
