using UnityEngine;

public class Enemy : MonoBehaviour {

	public EnemyController controller;

	void Update () {
		transform.Translate(controller.transform.position - transform.position);
	}

}
