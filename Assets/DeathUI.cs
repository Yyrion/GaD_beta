using UnityEngine;
using UnityEngine.UI;

public class DeathUI : MonoBehaviour
{
    public CanvasGroup deathPanel;
    public float fadeDuration = 1f;

    public void ShowDeathPanel()
    {
        StartCoroutine(FadeInPanel());
    }

    private System.Collections.IEnumerator FadeInPanel()
    {
        deathPanel.gameObject.SetActive(true);
        deathPanel.interactable = true;
        deathPanel.blocksRaycasts = true;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            deathPanel.alpha = Mathf.Clamp01(timer / fadeDuration);
            yield return null;
        }
        Time.timeScale = 0f;
    }
}