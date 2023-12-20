using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button tryAgainButton;

    [SerializeField] private float fadeDuration = 1f;

    private CanvasGroup canvasGroup;

    private void Awake() 
    {
        tryAgainButton.onClick.AddListener(() =>
        {
            GameManager.Instance.NewGame();
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
        });

        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver()
    {
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        int delaySeconds = 1;
        yield return new WaitForSeconds(delaySeconds);
        canvasGroup.DOFade(1f, fadeDuration);

        canvasGroup.interactable = true;
    }
}
