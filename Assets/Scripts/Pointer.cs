using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

	private float speed = 12;
	private Vector3 newDirection;
	private Vector3 lastDirection;

	private void Start() {
		Random.InitState(System.DateTime.Now.Millisecond);
		newDirection = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
		lastDirection = transform.position;
	}

	private void Update()	{
		transform.position += newDirection.normalized * speed * Time.deltaTime;
		ChangeDirection();
	}

	private void ChangeDirection() {
		if(transform.position.x >= 11.45f) {
			if (lastDirection.y >= transform.position.y) {
				newDirection = new Vector3(-0.5f,-0.5f, 0);
			}
			else {
				newDirection = new Vector3(-0.5f,0.5f, 0);
			}
			lastDirection = transform.position;
		}
		if (transform.position.x <= -11.45f) {
			if (lastDirection.y >= transform.position.y) {
				newDirection = new Vector3(0.5f,-0.5f, 0);
			}
			else {
				newDirection = new Vector3(0.5f,0.5f, 0);
			}
			lastDirection = transform.position;
		}
		if(transform.position.y >= 9.1f) {
			if (lastDirection.x >= transform.position.x) {
				newDirection = new Vector3(-0.5f,-0.5f, 0);
			}
			else {
				newDirection = new Vector3(0.5f,-0.5f, 0);
			}
			lastDirection = transform.position;
		}
		if (transform.position.y <= -8.1f) {
			if (lastDirection.x >= transform.position.x) {
				newDirection = new Vector3(-0.5f,0.5f, 0);
			}
			else {
				newDirection = new Vector3(0.5f,0.5f, 0);
			}
			lastDirection = transform.position;
		}
	}
}
