using UnityEngine;
using UnityEngine.InputSystem; //새 입력 시스템 사용

public class UpdateMove : MonoBehaviour
{
    public float Speed = 0.1f; // 이동 속도

    void Update()
    {
        // 새 입력 시스템: Keyboard.current 사용
        float moveX = 0f;
        float moveY = 0f;

        if (Keyboard.current.upArrowKey.isPressed) moveY += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY -= 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX += 1f;

        // 정규화 (대각선 이동 시 속도 일정)
        Vector3 moveDir = new Vector3(moveX, moveY, 0f).normalized;

        // 이동
        transform.position += moveDir * Speed;
    }
}
