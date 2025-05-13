using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image healthbar;
    private void Start()
    {
        healthbar = GetComponent<Image>();
    }

    public void UpdateHealth(int currentHealth) {
        healthbar.fillAmount = currentHealth/100f; }
}
