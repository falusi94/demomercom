using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
	public Transform heartContainer;
	public int maxHealth;
	private int health;
	private Animator animator;


	// Use this for initialization
	void Start () {
		health = maxHealth;
		animator = this.GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void attacked( int strength ) {
		health -= strength;
		setHearts ();
		if (health < 0) {
			animator.SetInteger ("AnimationState", 2);
			Attack attackScript = GetComponentInParent<Attack> ();
			attackScript.enabled = false;
			Movement movementScript = GetComponentInParent<Movement> ();
			movementScript.enabled = false;
			animator.SetBool ("isAttacking", false);
		}
	}

	private void setHearts() {
		float healtPercent = (health / (float)maxHealth) * 5;
		for (int i = 0; i < 5; i++) {
			heartContainer.GetChild (i).gameObject.SetActive (i-.5f<healtPercent);
		}

	}
}
