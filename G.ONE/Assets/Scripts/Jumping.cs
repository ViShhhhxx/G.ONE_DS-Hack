using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumpForce = 5f; 
    public float jumpCooldown = 1f;
    private float lastJumpTime;
    private bool isJumping;
    public Animator animator;
    public Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        lastJumpTime = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastJumpTime > jumpCooldown)
        {
            Jump();
        }
    }

    public void Jump()
    {
        animator.SetBool("isJumping", true);
        rb.velocity = new Vector3(0, jumpForce, 0);
        isJumping = true;
        GameManager.Instance.isJumping = true;
        lastJumpTime = Time.time;
        Invoke("EndJumpAnimation", 0.5f); 
    }

    void EndJumpAnimation()
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
