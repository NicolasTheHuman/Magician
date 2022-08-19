using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
	//float dirY;
	bool movingRight;
	bool movingUp;
	public bool moveDirY = true;
	public float moveSpeed = 3f;
	public float maxParameter;
	public float minParameter;

    // Update is called once per frame
    void Update()
    {
		if (moveDirY)
			MoveUp();
		else
			MoveRight();
    }

	void MoveUp()
	{
		if (transform.localPosition.y <= minParameter)
			movingUp = true;
		else if (transform.localPosition.y >= maxParameter)
			movingUp = false;

		if (movingUp)
			transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + moveSpeed * Time.deltaTime);
		else
			transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - moveSpeed * Time.deltaTime);

	}

	void MoveRight()
	{
		if (transform.localPosition.x <= minParameter)
			movingRight = true;
		else if (transform.localPosition.x >= maxParameter)
			movingRight = false;

		if (movingRight)
			transform.localPosition = new Vector2(transform.localPosition.x + moveSpeed * Time.deltaTime, transform.localPosition.y);
		else
			transform.localPosition = new Vector2(transform.localPosition.x - moveSpeed * Time.deltaTime, transform.localPosition.y);
	}

}
