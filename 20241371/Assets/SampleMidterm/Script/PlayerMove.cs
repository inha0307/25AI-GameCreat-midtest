using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float MoveAcceleration = 0.1f;
    public float JumpAcceleration = 0.1f;
    public float MaxJumpPower = 1f;
    public float MaxMovePower = 1f;
    bool isGrounded = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveX = 0f;
        float moveY = 0f;

        

        if (Keyboard.current.leftArrowKey.isPressed)
            moveX -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed)
            moveX += 1f;
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(Vector2.up * JumpAcceleration, ForceMode2D.Impulse);
        }
        if (rb.linearVelocity.y > MaxJumpPower)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, MaxJumpPower);
        if (rb.linearVelocity.x > MaxMovePower)
            rb.linearVelocity = new Vector2(MaxMovePower, rb.linearVelocity.y);
        if(rb.linearVelocity.x < -MaxMovePower)
            rb.linearVelocity = new Vector2(-MaxMovePower, rb.linearVelocity.y);
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;
        rb.AddForce(moveDir * MoveAcceleration, ForceMode2D.Force);
        // - Force : 지속적인 힘 (가속도형)
        // - Impulse : 순간적인 힘 (점프, 총알 발사 등에 사용)
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        if (collision.gameObject.CompareTag("Red"))
        {
            Debug.Log("빨간벽 충돌");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Green"))
        {
            Debug.Log("초록벽 충돌");
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }
}
