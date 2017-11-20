using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			animator.SetBool ("isAttacking", true);
			animator.CrossFade ("Attack1H", 1);
		}
	}
}
