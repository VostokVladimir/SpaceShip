using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal  class MoveTransform:IMove
    {

        #region " Урок 2 Задание 3.Переделать движение корабля через физику "
       
        ///private readonly Transform _transform;
        private readonly Rigidbody _rigidbody;
        public float Speed { get; protected set;}//ограничили скрипт свойством по принципу открытости закрытости
        private Vector3 _move;


        //public MoveTransform(Transform transform, float speed)
        //{
        //    _transform = transform;
        //    Speed = speed;
        //}

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
            //_transform.localPosition = _transform.localPosition + _move;
            _rigidbody.velocity += _move;//альтернативный вариант движения с физикой
        }

    }
}
