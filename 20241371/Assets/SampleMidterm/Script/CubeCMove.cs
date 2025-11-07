using UnityEngine;
using UnityEngine.InputSystem;

public class CubeCMove : MonoBehaviour
{
    public float Speed = 0.1f;
    public float TimeSpeed = 1f;
    Rigidbody2D rb;
    bool isSlow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        //  t 키를 "한 번 눌렀을 때만" 반응
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            isSlow = !isSlow; // 상태 토글
            TimeSpeed = isSlow ? 0.2f : 1f; // 슬로우모션  정상속도
            Debug.Log("TimeSpeed: " + TimeSpeed);
        }

        Time.timeScale = TimeSpeed;

        //  이동 처리
        Vector2 moveDir = new Vector2(Speed, 0f);
        rb.linearVelocity = moveDir*Time.deltaTime;
    }
}
