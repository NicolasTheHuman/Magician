using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighningBolt : MonoBehaviour
{
	public int damage = 1;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.layer != 6)
		{
			Destroy(gameObject);
		}
	}
}
