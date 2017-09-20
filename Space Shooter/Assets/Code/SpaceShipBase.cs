using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class SpaceShipBase : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1.5f;

        private Weapon[] _weapons;

        private Health _health;

        public float Speed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }

        public Weapon[] Weapons
        {
            get{ return _weapons; }
        }

        protected virtual void Awake()
        {
            _weapons = GetComponentsInChildren<Weapon>(includeInactive:true);
            _health = GetComponent<Health>();
        } 

        protected void Shoot()
        {
            foreach(Weapon weapon in Weapons)
            {
                weapon.Shoot();
            }
        }

        protected abstract void Move();

        protected virtual void Update()
        {
            Move();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            _health.DecreaseHealth(projectile.GetDamage());
        }
    }
}