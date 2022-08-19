using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
	public GameObject target;
	public float speed = 10f;
	Rigidbody2D rb;
	Vector3 direction;
	
    // Start is called before the first frame update
    void Start()
    {
		target = GameObject.Find("Wizard");
		rb = GetComponent<Rigidbody2D>();
		direction = (target.transform.position - transform.position).normalized * speed;
		rb.velocity = new Vector2(direction.x, direction.y);
	}
}
