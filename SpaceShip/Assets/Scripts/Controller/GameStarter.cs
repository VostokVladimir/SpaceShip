using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Opject_Pool;


namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        
        private void Start()
        {
            //Enemy.CreatesAsteroidEnemy(new Health(100.0f, 100.0f));

            //ДЗ Урок 3 Добавить еще типы врагов через статический метод
            //Enemy.CreateEnemyShip(new Health(50.0f, 50.0f));



            IEnemyFactory factory = new AsteroidFactory();
           // factory.Create(new Health(100, 100));

            Enemy.Factory = factory;

            for (int i = 0; i <=1; i++)
            {
                var enemy = Enemy.Factory.Create(new Health(100, 100));
                Vector3 position = new Vector3();
                position.x = Random.Range(-4, 4);
                position.y = Random.Range(14, 10);
                position.z = -4;
                enemy.transform.position = position;
                var rb = enemy.GetComponent<Rigidbody>();

                //ДЗ Урок 3 Добавить движение врагов
                
                var asteroid = enemy.GetComponent<Asteroid>();
                asteroid.Rotate(rb);
                rb.angularVelocity = Random.insideUnitSphere * 3f;
                asteroid.MoveEnemy(rb);

            }



            //ДЗ Урок 3 Добавить еще типы врагов через добавление еще одной фабрики
            //Cпособ 1
            factory = new EnemyShipFactory();
            factory.Create(new Health(50, 50));

            //Способ 2
            // Enemy.Factory = factory;
            // var enemy1 = Enemy.Factory.Create(new Health(50, 50));


            EnemyPool enemyPool = new EnemyPool(5);
            var enemyFronPool = enemyPool.GetEnemy("Asteroid");
            enemyFronPool.transform.position = Vector3.one;
            enemyFronPool.gameObject.SetActive(true);

        }

        
        
    }


    


    
}
