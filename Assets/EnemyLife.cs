using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour {
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
		if (health < 0) {
			animator.SetInteger ("AnimationState", 2);
			EnemyAttack script = GetComponentInParent<EnemyAttack> ();
			script.enabled = false;
			animator.SetBool ("isAttacking", false);
		}
	}
}
