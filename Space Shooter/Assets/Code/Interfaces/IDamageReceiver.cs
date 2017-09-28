using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public interface IDamageReceiver
    {
        void TakeDamage(int amount);
    }
}
