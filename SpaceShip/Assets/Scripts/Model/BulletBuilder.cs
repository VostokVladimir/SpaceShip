using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Builder
{
    class BulletBuilder
    {
        protected GameObject _bulletObject;

        public BulletBuilder()
        {
            _bulletObject = new GameObject();
        }

        protected BulletBuilder(GameObject gameObject)
        {
            _bulletObject = gameObject;
        }

        public BulletVisualBuilder Visual => new BulletVisualBuilder(_bulletObject);
       


    }
}
