
using UnityEngine;

namespace Asteroids
{
    public sealed class EnemyShipFactory: IEnemyFactory
    {
        private Transform transform;
        
        public Enemy Create(Health hp)
        {
            var enemy = Object.Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));
            enemy.DependencyInjectHealth(hp);
          
            return enemy;
        }
    }
}
