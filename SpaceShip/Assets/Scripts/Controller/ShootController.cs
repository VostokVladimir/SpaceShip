using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{   //урок 2 выделяем отдельный модуль для стрельбы
    public class ShootController:MonoBehaviour
    {
        private readonly Rigidbody2D _bullet;
        private readonly Transform _barrel;
        private readonly float _force;

        public ShootController(Rigidbody2D bullet,Transform barrel,float force)

        {
            _bullet = bullet;
            _force = force;
            _barrel = barrel;

        }

        public void Shooting()
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position,_barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
            Invoke("DestroyBullet",1f);
        }

        public void DestroyBullet()//метод не запускается через инвок
        {
                                 
           Destroy(_bullet);//не могу использовать метод без монобихевиора

        } 


    }
}

