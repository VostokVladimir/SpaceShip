using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    /// <summary>
    /// Класс контроля движения Игрока
    /// </summary>
    /// 
    
    internal  class MoveTransform:IMove
    {
        //private SpaceBoundary spaceBoundary;

        #region " Урок 2 Задание 3.Переделать движение корабля через физику "


        private readonly Rigidbody _rigidbody;
        public float Speed { get; protected set;}//ограничили скрипт свойством по принципу открытости закрытости
        private Vector3 _move;

        

        public MoveTransform(Rigidbody rigidbody, float speed)
        {
           _rigidbody = rigidbody;
            Speed = speed;
        }

        #endregion

        public void Move(float horizontal, float vertical, float deltatime)
        {

            var speed = Speed * deltatime;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _rigidbody.velocity += _move;
        }   

    }
}
