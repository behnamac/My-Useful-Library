using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace WarMachine
{
    public class HealthControl : MonoBehaviour
    {
        public  UnityAction OnDead;

        [SerializeField] private float maxHealth=20f;

        [SerializeField] private bool isSliderBar;
        [ConditionalHide(nameof(isSliderBar),true)]
        [SerializeField] private Image healthBar;

        private float _currentHealth;
        private bool _shield;





        #region Unity Methods
        private void Awake()
        {
            _currentHealth = maxHealth;
        }

        #endregion

        #region Custom Methods

        //---------------Health------------------

        public void SetHealth(float value)
        {
            if (_shield && value<=0) return;
                _currentHealth +=value;

            if(isSliderBar)
            UpdateHealthBar();

            CheckHealth();

        }

        public float GetHealth()
        {
            return _currentHealth;
        }

        private void UpdateHealthBar()
        {
            if (healthBar == null) return;
            healthBar.fillAmount = _currentHealth / maxHealth;
        }

        public void UpgradeMaxHealth(float value)
        {
            maxHealth += value;
            _currentHealth = maxHealth;
        }

        

        private void CheckHealth()
        {
            if (_currentHealth > 0) return;
            Dead();
        }

        #endregion

        private void Dead()
        {
            OnDead?.Invoke();
            Destroy(this);
        }

        public void ActiveShield()
        {
            _shield = true;
            Invoke(nameof(DeactiveShield),4f);

        }
        private void DeactiveShield()
        {
            _shield = false;
        }
    }
}
