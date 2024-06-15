using System;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public string TankId { get; private set; }
    [SerializeField] private float maxHealth = 1.0f;
    [SerializeField] private float currentHealth;
    [SerializeField] private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        TankId = Guid.NewGuid().ToString(); 
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        UpdateHealthBar();
    }
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = currentHealth / maxHealth;
        }
    }

}
