using UnityEngine;
using UnityEngine.InputSystem;

public class CubeAMove : MonoBehaviour
{
    public float Speed = 0.0001f; // 이동 속도

    void Update()
    {

        // 정규화 (대각선 이동 시 속도 일정)
        Vector3 moveDir = new Vector3(Speed, 0f, 0f).normalized;

        // 이동
        transform.position += moveDir;
    }
}
