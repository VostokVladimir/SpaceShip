using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{   //урок 2 выделяем отдельный модуль для стрельбы
    public class ShootController:MonoBehaviour
    {
        public  GameObject _bullet;
        private BulletPool _bulletPool;
        private int poolCount=10;

        [SerializeField]public Transform _barrel;//точка выстрела
        public float _force;

        private void Awake()
        {
            _bullet = Resources.Load<GameObject>("Sphere");
            _bulletPool = new BulletPool(_bullet, poolCount, this.transform);
            _bulletPool.autoExpand=true;
            _force = 1000;
        }

               
        public void Shooting()
        {
           
            var temAmmunition = _bulletPool.GetFreeObject();
            temAmmunition.transform.position = _barrel.position;
            temAmmunition.transform.rotation = _barrel.rotation;
            var rigidbody_pool_bullet = temAmmunition.GetComponent<Rigidbody>();
            rigidbody_pool_bullet.AddForce(_barrel.up * _force);

          // StartCoroutine(Disactivation_objectPool(temAmmunition));//при дизактивации обьектов пула обнуляется ссылка на GO. почему ?
                      
           
        }
                

        IEnumerator Disactivation_objectPool(GameObject gameObject)
        {
            yield return new WaitForSeconds(5f);
            gameObject.SetActive(false);
        }

    }
}

