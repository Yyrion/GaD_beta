using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HoverButtonColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color normalColor = Color.white;
    public Color hoverColor = Color.cyan;

    public float fadeDuration = 0.3f;

    private TextMeshProUGUI text;
    private Color targetColor;
    private float t;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        targetColor = normalColor;
        text.color = normalColor;
    }

    void Update()
    {
        // Interpolation douce entre la couleur actuelle et la couleur cible
        text.color = Color.Lerp(text.color, targetColor, Time.deltaTime / fadeDuration);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetColor = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetColor = normalColor;
    }
}
