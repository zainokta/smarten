using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    Transform target;
    [SerializeField] float minX = 11;
    [SerializeField] float maxX = 13;
    Transform t;

    private void Awake()
    {
        target = GetComponentInParent<Transform>();
        t = transform;
    }
	
	void LateUpdate () {
        float x = Mathf.Clamp(target.position.x, minX, maxX);
        t.position = new Vector3(x, transform.position.y, transform.position.z);
	}

}
