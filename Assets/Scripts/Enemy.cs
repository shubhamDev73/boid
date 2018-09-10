using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyController controller;
	public Transform destination;
	public float minFlockDistance;
	public float speed;
	
	void Update () {
		if((destination.position - transform.position).magnitude > minFlockDistance)
			transform.Translate((destination.position - transform.position).normalized * speed);

		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
			if((enemy.transform.position - transform.position).magnitude < minFlockDistance)
				transform.Translate((transform.position - enemy.transform.position).normalized * speed);
		}
	}

}
