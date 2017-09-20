using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class Health : MonoBehaviour, IHealth
    {
        [SerializeField] //This ensures that the variables show up in the Unity Editor.
        private int _startingHealth = 100; //Sets the starting health of the object.
        [SerializeField]
        private int _minimumHealth = 0; //Sets the minimum health the object can have.
        [SerializeField]
        private int _maximumHealth = 100; //Sets the maximum health the object can have.
        [SerializeField]
        private int _currentHealth; //Creates a variable called _currentHealth.

        public void Awake()
        {
            _currentHealth = _startingHealth; //The current health is set to be the same as the starting health.
        }

        public int CurrentHealth
        {
            get
            {
                return _currentHealth; //Returns the current health of the object.
            }
        }

        public void DecreaseHealth(int amount)
        {
            if (_currentHealth - amount <= _minimumHealth)
            {
                _currentHealth = 0;
                return; //If the current health is less than or equal to the minimum health, the game ends.
            }
            else
            {
                _currentHealth -= amount; //A certain amount of damage is decreased from the current health.
            }
        }

        public void IncreaseHealth(int amount)
        {
            if (_currentHealth + amount < _maximumHealth)
            {
                _currentHealth += amount; //If the current health and the amount of health that will recovered
                                          //are less than the maximum health variable, the object recovers health
                                          //to that of the amount.
            }
            else
            {
                _currentHealth = _maximumHealth; //This prevents the current health variable going
                                                 //above the amount of the maximum health variable.
            }
        }
    }
}
