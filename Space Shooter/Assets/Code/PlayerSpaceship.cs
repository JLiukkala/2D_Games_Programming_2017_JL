﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PlayerSpaceship : SpaceShipBase
    {
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string FireButtonName = "Fire1";

        //[SerializeField]
        public int playerLives;

        [SerializeField]
        private float _immortalTime = 1;

        private float _blinkInterval = 0.1f;

        public override Type UnitType
        {
            get { return Type.Player; }
        }

        private Vector3 GetInputVector()
        {
            float horizontalInput = Input.GetAxis(HorizontalAxis);
            float verticalInput = Input.GetAxis(VerticalAxis);

            return new Vector3(horizontalInput, verticalInput);
        }

        protected override void Update()
        {
            base.Update();

            if (Input.GetButton(FireButtonName))
            {
                Shoot();
            }
        }

        protected override void Move()
        {
            Vector3 inputVector = GetInputVector();
            Vector2 movementVector = inputVector * Speed;
            transform.Translate(movementVector * Time.deltaTime);
        }

        protected override void Die()
        {
            base.Die();
            GameManager.Instance.CurrentLives--;
        }

        public void BecomeImmortal()
        {
            var coroutine = StartCoroutine(ImmortalRoutine());
        }

        private IEnumerator ImmortalRoutine()
        {
            Health.SetImmortal(true);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                throw new System.Exception("No renderer found from PlayerSpaceship object!");
            }

            float timer = 0f;
            Color color = spriteRenderer.color;

            while (timer < _immortalTime)
            {
                timer += _blinkInterval;
                color = spriteRenderer.color;
                // These two below are the same thing (if-else).
                color.a = color.a == 1 ? 0 : 1;
                //if (color.a == 1)
                //{
                //    color.a = 0;
                //}
                //else
                //{
                //    color.a = 1;
                //}
                spriteRenderer.color = color;

                yield return new WaitForSeconds(_blinkInterval);
            }

            color = spriteRenderer.color;
            color.a = 1;
            spriteRenderer.color = color;

            Health.SetImmortal(false);
        }
    }
}
