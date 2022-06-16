using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Builder
{
    class BulletVisualBuilder : BulletBuilder
    {
        public BulletVisualBuilder(GameObject gameObject) : base(gameObject)
        { }

        public BulletVisualBuilder Name(string name)
        {
            _bulletObject.name = name;
            return this;
        }

        public BulletVisualBuilder Sprite(Sprite sprite)
        {
            var add_component = GetOrAddComponent<SpriteRenderer>();
            add_component.sprite = sprite;
            return this;

        }

        private T GetOrAddComponent<T>() where T:Component
       {
            var result = _bulletObject.GetComponent<T>();
            if(!result)
            {
                result = _bulletObject.AddComponent<T>();
            }
            return result;
       }
       
    }
}
