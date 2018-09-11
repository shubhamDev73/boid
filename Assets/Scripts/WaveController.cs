using System.Collections;
using UnityEngine;

public class WaveController : MonoBehaviour {

	public GameObject enemyControllerPrefab;
	public Transform[] spawnPoints;
	public Transform player;
	public float minDistanceBetweenEnemies;
	public float maxDistanceBetweenEnemies;

	private EnemyController[] enemyControllers;

	public void CreateWave(int enemies) {
		for(int i = 0; i < spawnPoints.Length; i++){
			EnemyController script = enemyControllers[i];
			script.player = player;
			script.randomPlace = Random.value * (maxDistanceBetweenEnemies - minDistanceBetweenEnemies) + minDistanceBetweenEnemies;
			script.CreateEnemies(enemies / spawnPoints.Length);
		}
	}

	void Start () {
		enemyControllers = new EnemyController[spawnPoints.Length];
		for(int i = 0; i < spawnPoints.Length; i++){
			GameObject enemyController = Instantiate(enemyControllerPrefab);
			enemyController.transform.position = spawnPoints[i].position;
			enemyControllers[i] = enemyController.GetComponent<EnemyController>();
		}
		StartCoroutine(Game());
	}

	IEnumerator Game () {
		while(true){
			CreateWave(20);
			yield return new WaitForSeconds(10);
		}
	}

}
