using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovinPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    double travelTime = 5f;
    float initialX;
    float initialY;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        rb.velocity = new Vector2(.2f, .2f);
        initialX = rb.position.x;
        initialY = rb.position.y;
    }

    // Update is called once per frame
    void Update() {
        travelTime -= Time.deltaTime;
        if(travelTime <= 0)
        {
            travelTime = Random.Range(0f, 10f);
            rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            rb.transform.position = new Vector2(initialX, initialY);
        }
    }
}
