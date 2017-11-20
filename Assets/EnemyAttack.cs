using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public GameObject target;
	public float followSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.transform.position, transform.position);

		if (distance < 25f) {
			float deltaTime = Time.deltaTime;
			Vector3 dv = new Vector3 (0,0,0);

			bool left = target.transform.position.x - transform.position.x < 0;
			bool right = target.transform.position.x - transform.position.x > 0;

			if (right) dv += new Vector3(followSpeed * deltaTime,0,0);
			if (left) dv += new Vector3(-followSpeed * deltaTime,0,0);
			transform.position += dv;

			Vector3 s = transform.localScale;
			if (dv.x < 0)
				transform.localScale = new Vector3 (-Mathf.Abs (s.x), s.y, s.z);
			else
				transform.localScale = new Vector3 (Mathf.Abs (s.x), s.y, s.z);
		}
	}
}
