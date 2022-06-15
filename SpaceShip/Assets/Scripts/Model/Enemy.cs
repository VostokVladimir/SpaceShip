using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour //IExplosion
    {
        public Health Health { get;  private set; }
        public static IEnemyFactory Factory;
       


       
        public static Asteroid CreatesAsteroidEnemy(Health hp)
        {

            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Asteroid"));//при модификаторе доступа internal classes Asteroid and Health не был доступен in class Enemy спросить у учителя почему ?
            

            return enemy;

        }


        #region " ДЗ к уроку 3 : Добавить еще тип врагов через статический метод"
        /// <summary>
        /// Добавление вражеских звездолетов через статический метод
        /// </summary>
        /// <param name="hp"></param>
        /// <returns></returns>
        public static EnemyShip CreateEnemyShip(Health hp)
        {

            var enemyship = Instantiate(Resources.Load<EnemyShip>("Enemy/EnemyShip"));

            return enemyship;

        }

        #endregion

        public void  DependencyInjectHealth(Health hp)
        {
            this.Health = hp;
            

        }
            

        /// <summary>
        /// Метод попадания пули во врага
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "bullet")
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
                var explosion = Resources.Load<GameObject>("Explosion/Explosion loop_2 sharp");
                               
                 MakeExplosion();

            }
        }

        /// <summary>
        /// Метод реализующий instance взрыва при уничтожении врага
        /// </summary>
        public void MakeExplosion() 
        {
            var explosion = Resources.Load<GameObject>("Explosion/Explosion loop_2 sharp");

            GameObject instance = Instantiate(explosion, GetComponent<Rigidbody>().position, GetComponent<Rigidbody>().rotation);
            Destroy(instance, 1f);
        }


    }
}
