using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public GameObject enemyPrefab;
	public float randomPlace;
	[@HideInInspector]
	public GameObject[] enemies;
	public float speed;

	public void CreateEnemies (int n) {
		enemies = new GameObject[n];
		for(int i = 0; i < n; i++){
			GameObject enemy = Instantiate(enemyPrefab);
			enemy.transform.position = transform.position + new Vector3(Random.value * randomPlace - randomPlace/2, 0, Random.value * randomPlace - randomPlace/2);
			Enemy script = enemy.GetComponent<Enemy>();
			script.controller = this;
			enemies[i] = enemy;
		}
	}

	void Start () {
		CreateEnemies(5);
	}

	void Update () {
		if((player.position - transform.position).sqrMagnitude > 1f)
			transform.Translate((player.position - transform.position).normalized * speed);
	}

}
