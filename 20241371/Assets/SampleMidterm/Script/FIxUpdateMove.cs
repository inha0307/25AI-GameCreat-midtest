using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
public class FixUpdate : MonoBehaviour
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
        rb.MovePosition(rb.position + moveDir * Speed);
    }
}