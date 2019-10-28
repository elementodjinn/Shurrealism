using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    public float maxTime = 5f;
    float travelTime;
    public float speedScaleX = 1f; //ranges, explicit speed if random is off
    public float speedScaleY = 1f;
    public bool rand = true;
    float initialX;
    float initialY;
    // Start is called before the first frame update
    void Start()
    {
        travelTime = maxTime;
        rb = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        if (rand) rb.velocity = new Vector2(Random.Range(-speedScaleX, speedScaleX), Random.Range(-speedScaleY, speedScaleY));
        else rb.velocity = new Vector2(speedScaleX, speedScaleY);
        initialX = rb.position.x;
        initialY = rb.position.y;
    }

    // Update is called once per frame
    void Update() {
        travelTime -= Time.deltaTime;
        if (travelTime <= 0){
            if (rand)
            {
                travelTime = Random.Range(0f, maxTime);
                rb.velocity = new Vector2(Random.Range(-speedScaleX, speedScaleX), Random.Range(-speedScaleY, speedScaleY));
                rb.transform.position = new Vector2(initialX, initialY);
            }
            else
            {
                travelTime = maxTime;
                rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
            }
        }
    }
}
