using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class AccelerationMove:MoveTransform
    {/// <summary>
    /// Расширяем функционал  класса MoveTransform добавляя новое поле , делаем как бы надстройку над данным классом
    /// </summary>
        private readonly float _acceleration;

        public AccelerationMove(Transform transform,float speed,float acceleration):base(transform,speed)//расширили базовый конструктор
        {
            _acceleration = acceleration;
        }
            
        public void AddAcceleration()
        {
            Speed += _acceleration;
        }
        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }
    }
}
