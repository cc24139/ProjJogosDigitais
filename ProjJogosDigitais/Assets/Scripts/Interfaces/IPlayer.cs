using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjJogosDigitais.Assets.Scripts.Interfaces
{
    public interface IPlayer
    {
        void Attack();
        void TakeDamge();
        void Die();
        void Super();
        void Move();
    }
}