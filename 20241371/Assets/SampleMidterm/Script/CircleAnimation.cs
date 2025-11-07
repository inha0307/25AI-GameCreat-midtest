using UnityEngine;

public class CircleAnimation : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;


    bool isBouncing = false;         // booing 중인가
    float bounceTimer = 0f;          // booing 경과시간
    bool Jumping = false;        // 현재 점프 중인가

    public float JumpPower = 10.0f;
    public float BooingDelay = 1.0f; // booing 지속시간

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !isBouncing)
        {
            Debug.Log("바닥 충돌 → 점프 준비");

            // booing 애니메이션 실행
            animator.Play("booing", -1, 0f);

            // booing 타이머 시작
            isBouncing = true;
            bounceTimer = 0f;
        }
    }

    void Update()
    {
        // booing 중이라면 시간 누적
        if (isBouncing)
        {
            bounceTimer += Time.deltaTime;

            if (bounceTimer >= BooingDelay)
            {
                rb.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
                animator.Play("jump", -1, 0f);

                isBouncing = false;
                Jumping = true;
            }
        }

        // 속도로 착지 상태 판정
        if (rb.linearVelocity.y < 0.01f && rb.linearVelocity.y > -0.01f)
        {
            Jumping = false;
        }
    }
}
