using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAp : MonoBehaviour
{

    public ApManager ApManager;
    public float chipSpeed = 2.0f;
    private float lerpTimer;
    public float maxHealth = 250f;

    public Image frontHealth;
    public Image backHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApManager.hp = Mathf.Clamp(ApManager.hp, 0, maxHealth);
        UpdateHealthUi();
    }

    public void UpdateHealthUi()
    {
        float fillF = frontHealth.fillAmount;
        float fillB = backHealth.fillAmount;
        float hFraction = ApManager.hp / maxHealth;

        if(fillB > hFraction)
        {
            frontHealth.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealth.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        ApManager.hp -= damage;
        lerpTimer = 0f;
    }
}
