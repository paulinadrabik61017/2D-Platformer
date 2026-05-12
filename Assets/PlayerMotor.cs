using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    private bool canJump = true;
    private Rigidbody2D rigidbody2D;
    public float speed = 5;
    public float jumpForce = 5;
    public float maxSpeed = 10;
    public float stoppingForce = 5;
    public float dashForce = 20;

    private bool canDash = true;
    private bool isDashing = false;

    private int _jumpCount = 0;
    public int maxJumpCount = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();

        HandleMaxSpeed();
        PlayerStopping();
    }

    private void PlayerStopping()
    {
        if (direction.x == 0 && rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void HandleMaxSpeed()
    {
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }

        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    private void MovePlayer()
    {
        rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
    }

    private void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    private void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            _jumpCount++;
            if (_jumpCount >= maxJumpCount)
            {
                canJump = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }

    private void OnDash()
    {
        if (canDash && direction.x !=0)
        {
            StartCoroutine(DashRoutine());
        }
    }
    private System.Collections.IEnumerator DashRoutine()
    {
        canDash = false;
        isDashing = true;

        float orginalGravity = rigidbody2D.gravityScale;
        rigidbody2D.gravityScale = 0;
        rigidbody2D.linearVelocity = new Vector2(direction.x * dashForce, 0);
        yield return new WaitForSeconds(0.2f);
        rigidbody2D.gravityScale = orginalGravity;
        isDashing = false;
        yield return new WaitForSeconds(1f);
        canDash = true;

    }
}
