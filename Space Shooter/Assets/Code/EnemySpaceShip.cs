﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{ 
    public class EnemySpaceShip : SpaceShipBase
    {
        [SerializeField]
        private float _reachedDistance = 0.5f;

        [SerializeField]
        private int _score;

        // The power-up's chance to spawn.
        [SerializeField]
        private int chanceToSpawn;

        // The prefab of the power-up.
        [SerializeField]
        private GameObject _powerUpPrefab;

        private GameObject[] _movementTargets;

        private int _currentMovementTargetIndex = 0;

        public Transform CurrentMovementTarget
        {
            get
            {
                return _movementTargets[_currentMovementTargetIndex].transform;
            }
        }

        public override Type UnitType
        {
            get { return Type.Enemy; }
        }

        protected override void Update()
        {
            base.Update();

            Shoot();
        }

        protected override void Die()
        {
            base.Die();
            if (LevelController.Current != null)
            {
                LevelController.Current.EnemyDestroyed();
            }

            // After an enemy is destroyed, there is a chance that it will 
            // spawn a power-up. The chance is adjustable from the Unity Editor.
            int i = Random.Range(0, 100);

            if (i < chanceToSpawn)
            {
                SpawnPowerUp();
            }

            GameManager.Instance.IncrementScore(_score);
        }

        public void SetMovementTargets(GameObject[] movementTargets)
        {
            _movementTargets = movementTargets;
            _currentMovementTargetIndex = 0;
        }

        protected override void Move()
        {
            if(_movementTargets == null || _movementTargets.Length == 0)
            {
                return;
            }

            UpdateMovementTarget();
            Vector3 direction = (CurrentMovementTarget.position - transform.position).normalized;
            transform.Translate(direction * Speed * Time.deltaTime);
        }

        private void UpdateMovementTarget()
        {
            if(Vector3.Distance(transform.position, CurrentMovementTarget.position) < _reachedDistance)
            {
                if(_currentMovementTargetIndex >= _movementTargets.Length - 1)
                {
                    _currentMovementTargetIndex = 0;
                }
                else
                {
                    _currentMovementTargetIndex++;
                }
            }
        }

        // Spawns the power-up in the position of the enemy ship.
        private void SpawnPowerUp()
        {
            _powerUpPrefab = Instantiate(_powerUpPrefab, transform.position, transform.rotation);
        }
    }
}

