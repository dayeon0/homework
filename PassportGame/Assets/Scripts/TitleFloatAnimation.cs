using UnityEngine;

/// <summary>
/// 타이틀 이미지에 둥실둥실 떠오르는 애니메이션을 적용합니다.
/// </summary>
public class TitleFloatAnimation : MonoBehaviour
{
    [Header("Float Settings")]
    public float floatAmplitude = 15f;   // 상하 이동 폭 (픽셀)
    public float floatSpeed = 1.2f;       // 속도

    [Header("Scale Pulse Settings")]
    public bool usePulse = true;
    public float pulseAmount = 0.03f;     // 크기 맥동 폭
    public float pulseSpeed = 1.5f;

    private Vector3 _startPosition;
    private Vector3 _startScale;
    private RectTransform _rectTransform;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.anchoredPosition3D;
        _startScale = _rectTransform.localScale;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        _rectTransform.anchoredPosition3D = _startPosition + new Vector3(0f, offsetY, 0f);

        if (usePulse)
        {
            float scale = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
            _rectTransform.localScale = _startScale * scale;
        }
    }
}
