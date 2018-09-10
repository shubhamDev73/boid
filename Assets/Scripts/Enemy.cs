using UnityEngine;

public class Enemy : MonoBehaviour {

	[@HideInInspector]
	public EnemyController controller;
	[@HideInInspector]
	public Transform destination;

	public float minDistance;
	public float speed;
	
	void Update () {
		transform.Translate((destination.position - transform.position).normalized * speed);

		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
			if((enemy.transform.position - transform.position).magnitude < minDistance)
				transform.Translate((transform.position - enemy.transform.position).normalized * speed);
		}

		if((destination.position - transform.position).magnitude < minDistance)
			transform.Translate((transform.position - destination.position).normalized * speed);

	}

}
