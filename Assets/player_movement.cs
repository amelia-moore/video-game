using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public float speed;

    public BoxCollider2D bounds;
    private Vector3 minBounds;
    private Vector3 maxBounds;

    // Start is called before the first frame update
    void Start()
    {
        // where map is
        minBounds = bounds.bounds.min;
        maxBounds = bounds.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        float clampx = Mathf.Clamp(transform.position.x + x*speed, minBounds.x, maxBounds.x);
        float clampy = Mathf.Clamp(transform.position.y + y*speed, minBounds.y, maxBounds.y);
        transform.position = new Vector3(clampx + x*speed, clampy + y*speed, transform.position.z);

        //gameObject.transform.position = new Vector2(transform.position.x + x*speed, 
        //transform.position.y + y*speed);
    }
}
