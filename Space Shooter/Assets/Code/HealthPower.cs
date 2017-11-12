using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class HealthPower : MonoBehaviour
    {
        // The amount of health the player recovers.
        [SerializeField]
        private int _healAmount;

        // The amount of time the power-up stays on 
        // the screen before it disappears.
        [SerializeField]
        private float _lifeTime;

        // How fast the power-up moves towards the bottom of the screen.
        [SerializeField]
        private float movementSpeed;

        void Update ()
        {
            // How the power-up starts moving down.
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);

            // Lessening the time that the power-up stays on the screen.
            _lifeTime -= 1;

            // If the lifetime of the power-up is zero, the power-up is destroyed.
            if(_lifeTime == 0)
            {
                Destroy(gameObject);
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            // The healing process of the player and the destruction 
            // of the power-up after the player picks it up.
            Health playerHealth = collision.GetComponent<Health>();
            playerHealth.IncreaseHealth(_healAmount);
            Debug.Log("Gained some health!");

            Destroy(gameObject);
        }
    }
} 
