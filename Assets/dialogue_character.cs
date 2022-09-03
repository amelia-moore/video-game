using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogue_character : MonoBehaviour
{

    public Camera cam;
    private float halfHeight;
    private float halfWidth;
    // Start is called before the first frame update
    void Start()
    {
        //cam = GetComponent<Camera>();
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        float clampx = Mathf.Clamp(transform.position.x, cam.transform.position.x, cam.transform.position.x);
        float clampy = Mathf.Clamp(transform.position.y, Camera.main.transform.position.y, Camera.main.transform.position.y);
        transform.position = new Vector3(cam.transform.position.x + halfWidth, cam.transform.position.y + halfHeight, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // * make this reveal itself multiple times instead of re-rendering everything constantly?
        // or just rerender it over and over again, whichever is better performance-wise
        float clampx = Mathf.Clamp(transform.position.x, Camera.main.transform.position.x + halfWidth, Camera.main.transform.position.x - halfWidth);
        float clampy = Mathf.Clamp(transform.position.y, Camera.main.transform.position.y + halfHeight, Camera.main.transform.position.y - halfHeight);
        transform.position = new Vector3(clampx, clampy, transform.position.z);
        transform.position = new Vector3(cam.transform.position.x + halfWidth - 1, cam.transform.position.y + halfHeight - 3, transform.position.z);
    }
}
