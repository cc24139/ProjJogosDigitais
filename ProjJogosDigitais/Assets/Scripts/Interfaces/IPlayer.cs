using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjJogosDigitais.Assets.Scripts.Interfaces
{
    public interface IDamage
    {
        public void TakeDamage(int damage);
        public void Die();

    }

    public interface IAttack
    {
        public int GetAtualAttack();
    }

    public interface IPlayer : IDamage, IAttack
    {
        public void Heal(int heal);
        public virtual void Attack() { }
        public virtual void Super() { }
        public virtual void Special() { }
    }

    
}