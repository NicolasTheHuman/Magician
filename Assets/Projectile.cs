using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public int damage = 2;
	public float speed;
	public float currentTime;
	float maxTime;
	Animator animator;
	Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.right * speed;
		maxTime = 3.5f;
    }

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
		if (currentTime >= maxTime)
			Destroy(gameObject);
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		animator.SetBool("Collision", true);
		Enemy enemy = collision.GetComponent<Enemy>();
		Boss boss = collision.GetComponent<Boss>();
		Hero hero = collision.GetComponent<Hero>();

		if (enemy != null)
			enemy.TakeDamage(damage);
		else if (boss != null)
			boss.TakeDamage(damage);
		else if (hero != null)
			hero.TakeDamage(damage);

		Destroy(gameObject, 0.5f);
	}
}
