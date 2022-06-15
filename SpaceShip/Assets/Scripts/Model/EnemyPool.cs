using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;
 

namespace Asteroids.Opject_Pool

{
    internal sealed class EnemyPool
    {

        private readonly Dictionary<string, HashSet<Enemy>> _enemyPool;
        private readonly int _capacityPool;
        private Transform _rootPool;

        public EnemyPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<Enemy>>(); //создаем словарик с ключом стринг и списком уникальных значений типа Враг
            _capacityPool = capacityPool; //характеристика врага 
            if (!_rootPool) 
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;//создаем пустышку GO ....ЗАЧЕМ ???
            }
            
        }

        /// <summary>
        /// Метод получения врага из списка Врагов по типу 
        /// </summary>
        /// <param name="type"></param>тип врага
        /// <returns></returns>
        public Enemy GetEnemy(string type)
        {
            Enemy result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                //case "EnemyShip":
                  //  result = GetEnemyShip(GetEnemies(type));
                  //  break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Такой тип врага не предусмотрен в программе");
                  
            }

            return result;
        }


        /// <summary>
        /// Создаем список Вагов в виде структуры данных  HashSet типа Enemyes;
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private HashSet<Enemy> GetListEnemies(string type)
        {
            

            if (_enemyPool.ContainsKey(type))
            {
                return _enemyPool[type];

            }

            return _enemyPool[type]=new HashSet<Enemy>(); 

            
        }

        private Enemy GetAsteroid(HashSet<Enemy> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if(enemy==null)
            {
                var asteroid = Resources.Load<Enemy>("Enemy/Asteroid");
                for(var i=0;i<=_capacityPool; i++)
                {
                    var instance = Object.Instantiate(asteroid);
                    ReturnToPool(instance.transform);
                    enemies.Add(instance);
                }

                GetAsteroid(enemies);
            }

            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);//что это не понятно
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }


    }
}
