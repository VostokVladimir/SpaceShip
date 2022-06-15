using System;
using System.Collections.Generic;


using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid:Enemy,IRotable
    {
        Rigidbody rigidbody_asteroid;
        [SerializeField]public  float tumble;
        [SerializeField] public float speed;


        /// <summary>
        /// Метод вращения астеройда
        /// </summary>
        /// <param name="rigidbody"></param>
        public void Rotate(Rigidbody rigidbody)
        {
           var rigibody= rigidbody.GetComponent<Rigidbody>();
            rigibody.angularVelocity= new Vector3(1, 1, 1) * tumble;
            rigidbody.angularDrag = 0;
            
            
             
        }

        public void MoveEnemy(Rigidbody rigidbody)
        {
            var rigibody = rigidbody.GetComponent<Rigidbody>();

            rigidbody.velocity = rigibody.transform.up *speed*-3f;
        }
    }
}
