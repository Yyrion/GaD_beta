using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Slider healthSlider;
    private void Start()
    {
        healthSlider = GetComponent<Slider>();
    }

    public void UpdateHealth(int currentHealth) {  healthSlider.value = currentHealth; }
}
