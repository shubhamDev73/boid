using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyController controller;
	public float minFlockDistance;
	
	void Update () {
		transform.Translate((controller.transform.position - transform.position).normalized * controller.speed);
		foreach(Transform enemy in controller.enemies){
			if((enemy.position - transform.position).magnitude < minFlockDistance)
				transform.Translate((enemy.position - transform.position).normalized * -1 * controller.speed);
		}
	}

}
