using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 150f;
    [SerializeField] float defaultMoveSpeed = 10f;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 7.5f;
    [SerializeField] float boostSpeed = 15f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Speed Up")
        {
            moveSpeed = boostSpeed;
        }else if(collision.tag == "Bumper")
        {
            moveSpeed = slowSpeed;
        }else if(collision.tag == "Customer")
        {
            moveSpeed = defaultMoveSpeed;
        }
    }
} // class
