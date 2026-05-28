using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// 게임 시작 화면 전체를 관리합니다.
/// </summary>
public class MainMenuManager : MonoBehaviour
{
    [Header("UI References")]
    public CanvasGroup titleCanvasGroup;    // 여권 주세요! 타이틀
    public CanvasGroup buttonCanvasGroup;   // 게임 시작 버튼
    public Button gameStartButton;

    [Header("Scene to Load")]
    public string gameSceneName = "GameScene";

    [Header("Fade-In Settings")]
    public float titleFadeInDuration = 1.2f;
    public float buttonFadeInDelay = 0.8f;
    public float buttonFadeInDuration = 0.8f;

    void Start()
    {
        // 시작 시 투명하게 설정
        if (titleCanvasGroup != null)  titleCanvasGroup.alpha = 0f;
        if (buttonCanvasGroup != null) buttonCanvasGroup.alpha = 0f;

        gameStartButton.onClick.AddListener(OnGameStartClicked);

        StartCoroutine(PlayIntroSequence());
    }

    IEnumerator PlayIntroSequence()
    {
        // 타이틀 페이드 인
        yield return StartCoroutine(FadeIn(titleCanvasGroup, titleFadeInDuration));

        // 버튼 페이드 인 (딜레이 후)
        yield return new WaitForSeconds(buttonFadeInDelay);
        yield return StartCoroutine(FadeIn(buttonCanvasGroup, buttonFadeInDuration));
    }

    IEnumerator FadeIn(CanvasGroup cg, float duration)
    {
        if (cg == null) yield break;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
        cg.alpha = 1f;
    }

    void OnGameStartClicked()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        // 버튼 클릭 후 전체 화면 페이드 아웃 후 씬 전환
        float duration = 0.6f;
        float elapsed = 0f;

        CanvasGroup root = GetComponentInParent<CanvasGroup>();
        if (root == null) root = gameObject.AddComponent<CanvasGroup>();

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            root.alpha = 1f - Mathf.Clamp01(elapsed / duration);
            yield return null;
        }

        SceneManager.LoadScene(gameSceneName);
    }
}
