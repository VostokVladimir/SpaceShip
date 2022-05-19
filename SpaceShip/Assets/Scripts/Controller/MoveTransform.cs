using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    internal  class MoveTransform:IMove
    {
        private readonly Transform _transform;
        public float Speed { get; protected set;}
        private Vector3 _move;
        

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltatime)
        {

            var speed = Speed * deltatime;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition = _transform.localPosition + _move;//задать вопрос учителю что это за local position?
        }

    }
}
