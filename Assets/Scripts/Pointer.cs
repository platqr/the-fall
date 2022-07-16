using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
	private float speed = 12;
	private Vector3 newDirection;

	private void Start() 
	{
		Random.InitState(System.DateTime.Now.Millisecond);
		newDirection = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
	}

	private void Update()
	{
		transform.position += newDirection.normalized * speed * Time.deltaTime;
		ChangeDirection();
		//transform.position = new Vector3(Mathf.Clamp(transform.position.x, -12f, 12f), Mathf.Clamp(transform.position.y, -9f, 9f), transform.position.z);
	}

	private void ChangeDirection()
	{
		if(transform.position.x >= 13f)
		{
			newDirection = new Vector3(Random.Range(-1f,0f), Random.Range(-1f,1f), 0);
		}
		if (transform.position.x <= -13f)
		{
			newDirection = new Vector3(Random.Range(0f,1f), Random.Range(-1f,1f), 0);
		}
		if (transform.position.y <= -10f)
		{
			newDirection = new Vector3(Random.Range(-1f,1f), Random.Range(0f,1f), 0);
		}
		if(transform.position.y >= 10f)
		{
			newDirection = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,0f), 0);
		}
	}
}
