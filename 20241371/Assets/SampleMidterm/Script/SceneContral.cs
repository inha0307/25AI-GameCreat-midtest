using UnityEngine;
using UnityEngine.InputSystem;

public class SceneContral : MonoBehaviour
{
    public float ScrollSpeed = 0.5f;  // 이동 속도 조절
    private Material myMaterial;

    void Start()
    {
        // 머티리얼 가져오기
        myMaterial = GetComponent<Renderer>().material;

        // 이미지가 반전되지 않고 반복되도록 Wrap Mode 설정
        myMaterial.mainTexture.wrapMode = TextureWrapMode.Repeat;
    }

    void Update()
    {

        // 화살표 입력값 받기
        float moveX = 0.0f;
        float moveY = 0.0f;

        if (Keyboard.current.upArrowKey.isPressed) moveY += 1f;
        if (Keyboard.current.downArrowKey.isPressed) moveY -= 1f;
        if (Keyboard.current.leftArrowKey.isPressed) moveX -= 1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveX += 1f;

        // 현재 텍스처 오프셋 가져오기
        Vector2 offset = myMaterial.mainTextureOffset;

        // 입력에 따라 오프셋 변경
        offset.x += moveX * ScrollSpeed * Time.deltaTime;
        offset.y += moveY * ScrollSpeed * Time.deltaTime;

        // 변경된 값 적용
        myMaterial.mainTextureOffset = offset;
    }
}