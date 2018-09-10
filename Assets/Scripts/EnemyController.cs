﻿using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public GameObject enemyPrefab;
	public float randomPlace;
	[@HideInInspector]
	public Transform[] enemies;

	public void CreateEnemies (int n) {
		enemies = new Transform[n];
		for(int i = 0; i < n; i++){
			GameObject enemy = Instantiate(enemyPrefab);
			enemy.transform.position = transform.position + new Vector3(Random.value * randomPlace - randomPlace/2, 0, Random.value * randomPlace - randomPlace/2);
			Enemy script = enemy.GetComponent<Enemy>();
			script.controller = this;
			script.destination = player;
			enemies[i] = enemy.transform;
		}
	}

}
