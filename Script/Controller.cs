using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Cubeboy;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;

    [SerializeField] private float crouchHeight = 0.25f;

    private bool isGrounded = false;
    private bool isJumping = false;
    private float jumpTimer;

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetButton("Jump"))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }

            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false ;
            jumpTimer = 0;
        }

        if (isGrounded && Input.GetButtonDown ("Crouch"))
        {
            Cubeboy.localScale = new Vector3(Cubeboy.localScale.x, crouchHeight, Cubeboy.localScale.z);

            if (isJumping)
            {
                Cubeboy.localScale = new Vector3(Cubeboy.localScale.x, 1f, Cubeboy.localScale.z);
            }
        }

        if (Input.GetButtonUp("Crouch"))
        {
            Cubeboy.localScale = new Vector3(Cubeboy.localScale.x, 1f, Cubeboy.localScale.z);
        }
    }
}
