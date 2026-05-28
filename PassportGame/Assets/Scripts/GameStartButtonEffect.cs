using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 게임 시작 버튼 호버/클릭 효과
/// </summary>
[RequireComponent(typeof(Button))]
public class GameStartButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("Scale Effect")]
    public float hoverScale = 1.08f;
    public float pressScale = 0.95f;
    public float lerpSpeed = 12f;

    [Header("Blink (깜빡임)")]
    public bool useBlink = true;
    public float blinkSpeed = 1.8f;
    public float blinkMin = 0.75f;

    private Vector3 _targetScale;
    private Vector3 _originalScale;
    private Image _image;
    private bool _isHovered;
    private bool _isPressed;

    void Start()
    {
        _originalScale = transform.localScale;
        _targetScale = _originalScale;
        _image = GetComponent<Image>();
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime * lerpSpeed);

        if (useBlink && !_isHovered && !_isPressed && _image != null)
        {
            float alpha = Mathf.Lerp(blinkMin, 1f, (Mathf.Sin(Time.time * blinkSpeed) + 1f) * 0.5f);
            Color c = _image.color;
            c.a = alpha;
            _image.color = c;
        }
        else if (_image != null)
        {
            Color c = _image.color;
            c.a = 1f;
            _image.color = c;
        }
    }

    public void OnPointerEnter(PointerEventData e) { _isHovered = true; _targetScale = _originalScale * hoverScale; }
    public void OnPointerExit(PointerEventData e)  { _isHovered = false; _isPressed = false; _targetScale = _originalScale; }
    public void OnPointerDown(PointerEventData e)  { _isPressed = true; _targetScale = _originalScale * pressScale; }
    public void OnPointerUp(PointerEventData e)    { _isPressed = false; _targetScale = _isHovered ? _originalScale * hoverScale : _originalScale; }
}
