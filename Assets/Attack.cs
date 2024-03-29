﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public Transform	enemies;
	public int			attackStrength = 10;
	public float		attackDistance = 3f;
	private Animator	animator;
	private float 		lastAttackTime;
	private bool		attacking;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator>();
		lastAttackTime = 0f;
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		float deltaTime = Time.deltaTime;
		lastAttackTime += deltaTime;

		if (lastAttackTime > 1f && attacking) {
			attacking = false;
		}

		if (Input.GetKey (KeyCode.Space) && !attacking) {
			attacking = true;
			lastAttackTime = 0f;
			animator.SetBool ("isAttacking", true);
			animator.CrossFade ("Attack1H", 1);

			int childCount = enemies.childCount;
			for ( int i=0; i<childCount; i++ ){
				Transform enemy = enemies.GetChild (i);
				float distance = Vector3.Distance (enemy.transform.position, transform.position);
				if (distance < attackDistance) {
					EnemyLife script = enemy.gameObject.GetComponent<EnemyLife> ();
					script.attacked (attackStrength);
				}
			}
		}
	}
}
