using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapController : MonoBehaviour
{
    public GameObject cubeBox;

    private Vector2 minX;
    private Transform t;
    private BoxCollider2D col;
    private Vector2 pos;
    

	// Use this for initialization
	void Start () {
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        t = GetComponent<Transform>();
        col = GetComponent<BoxCollider2D>();
        pos = transform.position;
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            col.isTrigger = false;
            InvokeRepeating("SpawnBox", 0, 2f);
        }
    }

    void SpawnBox()
    {
        Instantiate(cubeBox, new Vector2(transform.position.x,pos.y + 10f), Quaternion.identity);
        
        if(pos.x > minX.x)
        {
            pos.x -= 1;
        }
        else
        {
            pos.x += 1;
        }
    }
}
