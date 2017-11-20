using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {
	public int			numberOfEnemies = 5;
	public float		xMin;
	public float		xMax;
	public float		y;
	public Transform 	enemy1;
	public Transform 	enemy2;
	public Transform 	enemy3;
	public Transform	parentTransform;
	public GameObject	target;
	public int 			maxHealth = 100;

	// Use this for initialization
	void Start () {
		Transform[] enemyTypes = {enemy1, enemy2, enemy3};
		int numberOfEnemyType = enemyTypes.Length;
		float step = (xMax - xMin) / numberOfEnemies;

		for (int i = 0; i < numberOfEnemies; i++) {

			Transform obj = enemyTypes [Random.Range(0, numberOfEnemyType)];

			Transform enemy = GameObject.Instantiate (obj, parentTransform);
			EnemyAttack attackScript = enemy.gameObject.AddComponent<EnemyAttack> ();
			attackScript.target = target;

			EnemyLife lifeScript = enemy.gameObject.AddComponent<EnemyLife> ();
			lifeScript.maxHealth = maxHealth;

			enemy.localScale = new Vector3 (0.5f, 0.5f, 0.5f);

			enemy.transform.Translate ( new Vector3(
				Random.Range(i-1, i+1) * step + xMin,
				y,
				0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
