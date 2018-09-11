using UnityEngine;

public class Enemy : MonoBehaviour {

	[@HideInInspector]
	public EnemyController controller;
	[@HideInInspector]
	public Transform destination;

	public float minEnemyDistance;
	public float minPlayerDistance;
	public float speed;

	private enum State {Move, Attack};
	private State state = State.Move;
	
	void Update () {
		// avoid other enemies
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")){
			if((enemy.transform.position - transform.position).sqrMagnitude < minEnemyDistance)
				transform.Translate((transform.position - enemy.transform.position).normalized * speed);
		}

		// acting on the state
		if(state == State.Move)
			Move();

		if(state == State.Attack)
			Attack();
		
	}

	void Move () {
		transform.Translate((destination.position - transform.position).normalized * speed);

		if((destination.position - transform.position).sqrMagnitude < minPlayerDistance){
			transform.Translate((transform.position - destination.position).normalized * speed);
			state = State.Attack;
		}
	}

	void Attack () {
		// Attack

		if((destination.position - transform.position).sqrMagnitude > minPlayerDistance)
			state = State.Move;
	}

}
