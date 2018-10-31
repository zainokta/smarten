using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxController : MonoBehaviour {
    private float speed = 7;
    private Rigidbody2D RB;
    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update () {
        RB.velocity = new Vector2(0, -speed);
	}

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
