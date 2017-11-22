using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	public GameObject	target;
	public float		followSpeed = 2f;
	public float		runSpeed = 5f;
	public float		attackDistance = 3f;
	public int			attackStrength = 10;
	private Animator animator;
	private float lastAttackTime;
	private bool attacking;

	// Use this for initialization
	void Start () {
		animator = this.GetComponentInChildren<Animator>();
		lastAttackTime = 0f;
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (target.transform.position, transform.position);
		float deltaTime = Time.deltaTime;
		lastAttackTime += deltaTime;

		if (distance < 25f && distance > 3f) {
			Vector3 dv = new Vector3 (0,0,0);

			bool left = target.transform.position.x - transform.position.x < 0;
			bool right = target.transform.position.x - transform.position.x > 0;

			float speed = followSpeed;
			if (distance < 10f) {
				speed = runSpeed;
			}

			if (right) dv += new Vector3(speed * deltaTime,0,0);
			if (left) dv += new Vector3(-speed * deltaTime,0,0);
			transform.position += dv;

			if (dv.magnitude > 0f) {
				if (distance < 10f)
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

		if (lastAttackTime > 1f && attacking) {
			attacking = false;
		}

		if (distance < attackDistance && !attacking) {
			attacking = true;
			lastAttackTime = 0f;
			animator.SetBool ("isAttacking", true);
			animator.CrossFade ("Rouge_attack_01", 1);

			Life script = target.GetComponent<Life> ();
			script.attacked (attackStrength);

		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
}
