using UnityEngine;
using UnityEngine.InputSystem;

public class AddForceMove : MonoBehaviour
{
    public float Speed = 0.1f;
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

        if (Keyboard.current.upArrowKey.isPressed) moveY += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY -= 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX += 1f;

        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        rb.AddForce(moveDir * Speed, ForceMode2D.Force);
        // - Force : 지속적인 힘 (가속도형)
        // - Impulse : 순간적인 힘 (점프, 총알 발사 등에 사용)
    }
}