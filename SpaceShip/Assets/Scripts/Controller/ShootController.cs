using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{   //урок 2 выделяем отдельный модуль для стрельбы
    public class ShootController:MonoBehaviour
    {
        public  GameObject _bullet;
        [SerializeField]public Transform _barrel;
        public float _force;

        private void Awake()
        {
            _bullet = Resources.Load<GameObject>("Sphere");
            _force = 1000;
        }

               
        public void Shooting()
        {
            var rigidBoby = _bullet.GetComponent<Rigidbody2D>();
            var temAmmunition = Instantiate(rigidBoby, _barrel.transform.position,_barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
            Destroy(temAmmunition.gameObject, 2f);
        }





    }
}

