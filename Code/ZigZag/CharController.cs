﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public Transform rayCastStart;

    public Rigidbody rb;
    private bool walkingRight=true;

    public Animator anim;

    public GameManager gameManager;

    public GameObject crystalEffect;


    // Start is called before the first frame update
    void Awake()
    {
        rb.GetComponent<Rigidbody>();
        anim.GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }
    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            anim.SetTrigger("IsStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();

        }
        RaycastHit hit;
        if(!Physics.Raycast(rayCastStart.position,-transform.up,out hit,Mathf.Infinity))
        {
            anim.SetTrigger("IsFalling");
        }
        else
        {
            anim.SetTrigger("NotFallingAnymore");
        }
        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }

    }
    private void Switch()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }
        walkingRight = !walkingRight;
        if (walkingRight)
        {
            transform.rotation=Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, transform.position, Quaternion.identity);
            Destroy(g, 1);
            Destroy(other.gameObject);
        }
    }
}
