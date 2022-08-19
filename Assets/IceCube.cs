using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCube : MonoBehaviour
{
	public float lifeSpan = 5f;
    // Update is called once per frame
    void Update()
    {
		Destroy(gameObject, lifeSpan);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "FireBall")
			Destroy(gameObject);
	}
}
