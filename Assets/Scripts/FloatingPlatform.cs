﻿using UnityEngine;
using System.Collections;

public class FloatingPlatform : MonoBehaviour
{
	public float speed = 1f;
	public float height = 1f;
	float x = 0f;
	public Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		if (startPos == Vector3.zero)
		{
		    startPos = transform.position;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		//transform.position = new Vector3(transform.position.x, height * Mathf.Sin(speed * x) + startPos.y, transform.position.z);
        GetComponent<Rigidbody>().MovePosition(new Vector3(height * Mathf.Sin(speed * x) + startPos.x, transform.position.y, transform.position.z));
		//GetComponent<Rigidbody>().velocity = new Vector3(transform.position.x, height * Mathf.Sin(speed * x) + startPos.y, transform.position.z);
		//GetComponent<Rigidbody>().position = new Vector3(transform.position.x, height * Mathf.Sin(speed * x) + startPos.y, transform.position.z);
		x += Time.fixedDeltaTime;
	}

	void OnCollisionEnter (Collision other)
	{
		if (other.transform.tag == "Player")
		{
			transform.parent = other.gameObject;
		}
	}
}
