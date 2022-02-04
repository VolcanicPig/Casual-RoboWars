using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class HealthDisplay : MonoBehaviour
    {
        [SerializeField] private Health health; 
        [SerializeField] private Image healthFill;
        [Space] 
        [SerializeField] private float fillTime;
        
        private void OnEnable()
        {
            health.HealthChanged += OnHealthChanged; 
        }

        private void OnDisable()
        {
            health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            float currFillAmount = healthFill.fillAmount; 

            StartCoroutine(Helpers.LerpAction((percentDone) =>
            {
                healthFill.fillAmount = Mathf.Lerp(currFillAmount, health.PercentageOfMax, percentDone); 
            }, fillTime));
        }
    }
}