using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	public int life = 15;
	public int currentPortal;
	public float maxTime;
	public float currentTime;
	public Transform myFirePoint;
	public GameObject iceShard;
	public WaypointSystem portals;
	public GameObject hero;
	Animator myAnimator;
	AudioSource myAudioSource;
	bool facingRight;
    // Start is called before the first frame update
    void Start()
    {
		myAnimator = GetComponent<Animator>();
		myAudioSource = GetComponent<AudioSource>();
		hero = GameObject.Find("Wizard");

		Difficulty();
    }

    // Update is called once per frame
    void Update()
    {
		currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
		{
			Shoot();
		}
	}

	void Shoot()
	{
		myAnimator.Play("Boss_attack");
		currentTime = 0f;
		Instantiate(iceShard, myFirePoint.position, myFirePoint.rotation);
	}

	void Teleport()
	{
		currentPortal = Random.Range(0, portals.waypoints.Length);
		transform.position = portals.waypoints[currentPortal].position;

		if(transform.position.x > hero.transform.position.x && !facingRight)
		{
			Flip();
		}
		else if (transform.position.x < hero.transform.position.x && facingRight)
		{
			Flip();
		}
	}

	void Flip()
	{
		facingRight = !facingRight;
		transform.Rotate(0f, 180f, 0f);
	}

	public void TakeDamage(int damage)
	{
		life -= damage;
		myAudioSource.Play();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.layer == 16)
			Teleport();
	}

	void Difficulty()
	{
		switch (PlayerPrefs.GetInt("Difficulty"))
		{
			case 1:
				maxTime = 4f;
				life = 11;
				break;

			case 2:
				maxTime = 3f;
				life = 15;
				break;

			case 3:
				maxTime = 2.25f;
				life = 21;
				break;

		}
	}
}
