using UnityEngine;
using UnityEngine.InputSystem;

public class VelocityMove : MonoBehaviour
{
    public float Speed = 0.1f; // 이동 속도
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true; // 회전 방지
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
        // Rigidbody의 속도에 반영 → 중력, 마찰 등 물리효과 유지
        rb.linearVelocity = moveDir * Speed;
    }
}

