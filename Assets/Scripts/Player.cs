using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
	}

}
