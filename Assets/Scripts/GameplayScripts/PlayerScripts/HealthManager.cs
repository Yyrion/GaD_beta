using UnityEngine;

public class HealthManager : MonoBehaviour
{
    //private int maxHealth = 100;
    private int health = 100;

    public HealthUI HealthUI;
    public DeathUI DeathUI;
    void Start()
    {
        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
        HealthUI.UpdateHealth(health);
    }

    private void GameOver()
    {
        DeathUI.ShowDeathPanel();
        return;
    }
}
