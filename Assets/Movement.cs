using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpeed = 5f;
	public float xMin;
	public float xMax;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;
		if (Input.GetKey (KeyCode.Escape))	Application.Quit ();

		Vector3 dv = new Vector3 (0,0,0);
		bool left = Input.GetAxis ("Horizontal") < 0;
		bool right = Input.GetAxis ("Horizontal") > 0;
		//bool up = Input.GetAxis("Vertical") > 0;
		//bool down = Input.GetAxis("Vertical") < 0;

		if (right && transform.position.x < xMax) dv += new Vector3(moveSpeed * deltaTime,0,0);
		if (left && transform.position.x > xMin) dv += new Vector3(-moveSpeed * deltaTime,0,0);
		//if (up)	dv += new Vector3(0,movespeed * dt,0);
		//if (down)dv += new Vector3(0,-movespeed * dt,0);
		transform.position += dv;
		if (dv.magnitude > 0f)
			animator.SetInteger ("AnimationState", 1);
		else
			animator.SetInteger ("AnimationState", 0);

		Vector3 s = transform.localScale;
		if (dv.x < 0)
			transform.localScale = new Vector3 (-Mathf.Abs (s.x), s.y, s.z);
		else
			transform.localScale = new Vector3 (Mathf.Abs (s.x), s.y, s.z);
	}
}
