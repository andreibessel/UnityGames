﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public float movementSpeed;
    public GameObject ball;

    public void FixedUpdate()
    {
        if (Mathf.Abs(this.transform.position.y - this.ball.transform.position.y)>50)
        {
            if (transform.position.y < ball.transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * movementSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * movementSpeed;

            }
        }else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0) * movementSpeed;

        }
    }

    

}
