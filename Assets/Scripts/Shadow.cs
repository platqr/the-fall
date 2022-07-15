using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] private GameObject player;
		private SpriteRenderer rndrr;
		[SerializeField] private Color shadowColor;

		private void Awake() {
			rndrr = transform.GetComponent<SpriteRenderer>();
		}

    void Update()
    {
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
			if (detectFloor() && player.transform.position.z < transform.position.z)
			{
				rndrr.color = shadowColor;
			}
			else
			{
				rndrr.color = Color.clear;
			}
    }

		private bool detectFloor()
		{
			return Physics.Raycast(new Vector3(transform.position.x,transform.position.y,transform.position.z-.2f), Vector3.forward);
		}
}
