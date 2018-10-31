using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerController : MonoBehaviour {
    private Transform t;
    public GameObject cube;
    Vector2 pos;

	void Start () {
        t = GetComponent<Transform>();
        pos = new Vector2(t.position.x, t.position.y + 10);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Instantiate(cube, pos, Quaternion.identity);
        }
    }
}
