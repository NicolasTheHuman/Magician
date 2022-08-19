using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour
{
	Rigidbody2D rb;
	Animator animator;
	AudioSource src;
	bool facingLeft;
	bool isMoving = false;
	bool isJumping = false;
	
	public float speed = 5f;
	public float jumpForce;
	public float fireCooldown = 1f;
	public float iceCooldown = 1.5f;
	public float activeCooldown;
	public float currentTime;
	//public float currentTimeIceball;
	public int jumpAmount = 1;
	public int health = 5;
	public int maxHealth;
	public int numberOfHearts;
	public bool shootingFire = true;
	public bool upgrade = false;

	public Transform lastPlatform;
	public Transform firePoint;
	public Projectile fireBall;
	public Projectile iceBall;
	public Image[] hearts;
	public Image magicCooldownHUD;
	public Sprite fullHeart;
	public AudioClip walking;
	public AudioClip jumpFX;
	public AudioClip landing;
	public AudioClip takingDamage;
	public AudioClip pickUp;

    // Start is called before the first frame update
    void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		src = GetComponent<AudioSource>();
		maxHealth = health;
    }

    // Update is called once per frame
    void Update()
	{
		currentTime += Time.deltaTime;
		
		numberOfHearts = health;
		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < numberOfHearts)
			{
				hearts[i].enabled = true;
			}
			else
			{
				hearts[i].enabled = false;
			}
		}
		magicCooldownHUD.fillAmount = currentTime / activeCooldown;
	}

	public void Move(float horizontal)
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	
		animator.SetBool("Horizontal", true);

		if (horizontal < 0 && facingLeft)
		{
			Flip();
		}
		else if (horizontal > 0 && !facingLeft)
		{
			Flip();
		}
		else if (horizontal == 0)
		{
			animator.SetBool("Horizontal", false);
		}

		if (horizontal != 0)
			isMoving = true;
		else
			isMoving = false;
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		transform.Rotate(0f, 180f, 0f);
	}

	public void Jump()
	{
		rb.AddForce(transform.up * jumpForce);
		animator.SetBool("isJumping", true);
		isJumping = true;
		src.clip = jumpFX;
		src.Play();
	}

	public void Fire()
	{
		animator.Play("Casting");
		currentTime = 0f;
		if (shootingFire)
		{
			activeCooldown = fireCooldown;
			Instantiate(fireBall, firePoint.position, firePoint.rotation);
		}
		else if (!shootingFire)
		{
			activeCooldown = iceCooldown;
			Instantiate(iceBall, firePoint.position, firePoint.rotation);
		}
	}

	public void SwitchSpell()
	{
		shootingFire = !shootingFire;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		animator.SetBool("isJumping", false);

		jumpAmount = 1;

		isJumping = false;

		if (collision.gameObject.layer == 12)
			transform.parent = collision.transform;

		if(collision.gameObject.layer == 8)
		{
			Vector3 tempLastPlatform = collision.gameObject.transform.position;
			lastPlatform.position = new Vector3(0, 2, 0) + tempLastPlatform;

			src.clip = landing;
			src.Play();
		}

		if(collision.gameObject.layer == 13)
		{
			health--;
			transform.position = lastPlatform.position;
			src.clip = takingDamage;
			src.Play();
		}

		if (collision.gameObject.layer == 9 || collision.gameObject.layer == 11)
		{
			health--;
			animator.SetBool("isJumping", false);
			animator.Play("Take_Damage");
			src.clip = takingDamage;
			src.Play();
		}

		if(collision.gameObject.layer == 15)
		{
			//allows to swap spells
			upgrade = true;
			src.clip = pickUp;
			src.Play();
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.layer == 17)
		{
			health = maxHealth;
			src.clip = pickUp;
			src.Play();
		}
	}

	private void OnCollisionStay2D(Collision2D collision)
	{
		if(collision.gameObject.layer == 8)
		{
			if (isMoving && !isJumping)
			{
				src.clip = walking;
				if (!src.isPlaying)
					src.Play();
			}
			else if (!isMoving && src.clip == walking || isJumping && src.clip == walking)
				src.Stop();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.layer == 12)
			transform.parent = null;

		if(collision.gameObject.layer == 8)
		{
			isMoving = false;
		}
	}

	public void TakeDamage(int damage)
	{
		health -= damage;
		animator.SetBool("isJumping", false);
		animator.Play("Take_Damage");
		src.clip = takingDamage;
		src.Play();
	}
}
