using UnityEngine;
using UnityEngine.InputSystem;

public class CubeBMove : MonoBehaviour
{
    public float Speed = 0.0001f; // 이동 속도
    public float TimeSpeed = 1f; // 이동 속도
    bool isSlow = false;

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
        // 정규화 (대각선 이동 시 속도 일정)
        Vector3 moveDir = new Vector3(Speed, 0f, 0f).normalized;

        
        transform.position += moveDir*Time.deltaTime;
    }
}
