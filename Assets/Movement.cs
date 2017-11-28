using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
	public float moveSpeed = 5f;
	public float runSpeed = 10f;
	public float xMin;
	public float xMax;
	public Transform flag;
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

		float speed = moveSpeed;
		if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift)) {
			speed = runSpeed;
		}

		if (right && transform.position.x < xMax) dv += new Vector3(speed * deltaTime,0,0);
		if (left && transform.position.x > xMin) dv += new Vector3(-speed * deltaTime,0,0);
		//if (up)	dv += new Vector3(0,movespeed * dt,0);
		//if (down)dv += new Vector3(0,-movespeed * dt,0);
		transform.position += dv;
	
		if (Mathf.Abs(transform.position.x - xMax) < 1f) {
			gameObject.SetActive (false);
			Vector3 pos = flag.position;
			pos.y += 20;
			flag.position = pos;
		}

		if (dv.magnitude > 0f) {
			if (Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))
				animator.SetInteger ("AnimationState", 3);
			else
				animator.SetInteger ("AnimationState", 1);
		}
		else
			animator.SetInteger ("AnimationState", 0);

		Vector3 s = transform.localScale;
		if (dv.x < 0)
			transform.localScale = new Vector3 (-Mathf.Abs (s.x), s.y, s.z);
		else
			transform.localScale = new Vector3 (Mathf.Abs (s.x), s.y, s.z);
	}
}
