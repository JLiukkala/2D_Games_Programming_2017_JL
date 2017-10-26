using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] //This ensures that the variables show up in the Unity Editor.
        private int _initialHealth; //Sets the starting health of the object.
        [SerializeField]
        private int _minHealth; //Sets the minimum health the object can have.
        [SerializeField]
        private int _maxHealth; //Sets the maximum health the object can have.
        
        private int _currentHealth; //Creates a variable called _currentHealth.

        private bool _isImmortal = false;

        public void Awake()
        {
            CurrentHealth = _initialHealth; //The current health is set to be the same as the initial health.
        }

        public int CurrentHealth
        {
            get
            {
                return _currentHealth; //Returns the current health of the object.
            }
            private set
            {
                _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth);
            }
        }

        public int MaximumHealth
        {
            get
            {
                return _maxHealth;
            }
        } 

        public bool IsDead
        {
            get { return CurrentHealth == _minHealth; }
        }

        public void DecreaseHealth(int amount)
        {
            if (!_isImmortal)
            {
                CurrentHealth -= amount;
            }
        }

        public void IncreaseHealth(int amount)
        {
            CurrentHealth += amount;
        }

        public void SetImmortal (bool isImmortal) 
        {
            _isImmortal = isImmortal;
        }
    }
}
