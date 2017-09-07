using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public abstract class SpaceShipBase : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1.5f;

        public float Speed
        {
            get { return _speed; }
            protected set { _speed = value; }
        }

        protected abstract void Move();

        protected virtual void Update()
        {
            Move();
        }
    }
}