using UnityEngine;

public class EnemyController : MonoBehaviour {

	[@HideInInspector]
	public Transform player;
	[@HideInInspector]
	public float randomPlace;

	public GameObject enemyPrefab;

	public void CreateEnemies (int n) {
		for(int i = 0; i < n; i++){
			GameObject enemy = Instantiate(enemyPrefab);
			enemy.transform.position = transform.position + new Vector3(Random.value * randomPlace - randomPlace/2, 0, Random.value * randomPlace - randomPlace/2);
			enemy.transform.SetParent(GameObject.Find("EnemiesContainer").transform);
			Enemy script = enemy.GetComponent<Enemy>();
			script.controller = this;
			script.destination = player;
		}
	}

}
