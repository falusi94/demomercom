using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	public GameObject target;
	public float followSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;
		float fspeed = Mathf.Min(1.0f, followSpeed * deltaTime);

		Vector3 oldPositon = transform.position;
		Vector3 newPositon = oldPositon;
		newPositon.x = target.transform.position.x;		
		newPositon = oldPositon + (newPositon - oldPositon) * fspeed;		
		transform.position = newPositon;
	}
}
