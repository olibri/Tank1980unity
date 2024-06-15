using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
    public void UpdateHealth(float maxHealth, float currentHealth)
    {
        _healthBar.fillAmount = currentHealth/maxHealth;
    }

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position- camera.transform.position );
    }
}
