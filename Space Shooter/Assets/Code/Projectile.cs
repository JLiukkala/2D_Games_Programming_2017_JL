using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : MonoBehaviour, IDamageProvider
    {
        [SerializeField, UsedImplicitly]
        private int _damage;
        [SerializeField]
        private float _speed;

        private Rigidbody2D _rigidBody;
        private Vector2 _direction;
        private bool _isLaunched = false;
        private Weapon _weapon;
        private AudioSource _audio;

        protected virtual void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _audio = GetComponent<AudioSource>();

            if(_rigidBody == null)
            {
                Debug.LogError("No RigidBody2D component was found from the GameObject!");
            }
        }

        protected void FixedUpdate()
        {
            if (!_isLaunched)
            {
                return;
            }

            Vector2 velocity = _direction * _speed;
            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 newPosition = currentPosition + velocity * Time.fixedDeltaTime;
            _rigidBody.MovePosition(newPosition);
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            IDamageReceiver damageReceiver = other.GetComponent<IDamageReceiver>();
            if (damageReceiver != null)
            {
                Debug.Log("Hit a damage receiver.");
                damageReceiver.TakeDamage(GetDamage());
            }

            if (!_weapon.DisposeProjectile(this))
            {
                Debug.LogError("Could not return the projectile back to the pool!");
                Destroy(gameObject);
            }
        }

        public void Launch(Weapon weapon, Vector2 direction)
        {
            _weapon = weapon;
            _direction = direction;
            _isLaunched = true;

            _audio.PlayOneShot(_audio.clip, 1);
        }

        public int GetDamage()
        {
            return _damage;
        }
    }
}

