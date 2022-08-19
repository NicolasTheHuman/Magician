using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public WaypointSystem wpSystem;

	public float speed;
	public int currentWp;
	public int life = 6;
	public bool right = true;

	public enum EntityState { PATROL, CHASE };
	public EntityState state;

	public Transform hero;
	
	// Start is called before the first frame update
	void Start()
	{
		right = true;
		wpSystem = GameObject.Find("WaypointSystem").GetComponent<WaypointSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		
		if (state == EntityState.PATROL)
		{
			Patrol();
		}
		else
		{
			Chase();
		}
	}

	void ChangeState()
	{
		//state = state == EntityState.PATROL ? EntityState.PURSUIT : EntityState.PATROL;

		if (state == EntityState.PATROL)
		{
			state = EntityState.CHASE;
		}
		else
		{
			state = EntityState.PATROL;
		}
	}

	void Patrol()
	{
		Vector3 direction = wpSystem.waypoints[currentWp].position - transform.position;

		float distance = Vector3.Distance(transform.position, hero.position);
		if (distance < 2)
		{
			ChangeState();
		}

		
		if (direction.magnitude > speed * Time.deltaTime)
		{
			transform.position += direction.normalized * speed * Time.deltaTime;
		}
		else
		{
			transform.position = wpSystem.waypoints[currentWp].position;

			if (right)
			{
				currentWp++;
				if (currentWp >= wpSystem.waypoints.Length)
				{
					right = false;
					currentWp--;
				}
			}
			else
			{
				currentWp--;
				if (currentWp < 0)
				{
					right = true;
					currentWp++;
				}
			}
		}
	}
	
	void Chase()
	{
		float distance = Vector3.Distance(transform.position, wpSystem.waypoints[currentWp].position);
		if (distance > 5)
		{
			ChangeState();
		}

		Vector3 direction = hero.position - transform.position;

		transform.position += direction.normalized * speed * Time.deltaTime;
	}

	public void TakeDamage(int damage)
	{
		life -= damage;

		if (life <= 0)
			Destroy(gameObject);
	}
}
