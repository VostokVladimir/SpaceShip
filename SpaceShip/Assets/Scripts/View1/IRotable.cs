using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Asteroids
{/// <summary>
/// Интерфейс вращения астеройда
/// </summary>
    public interface IRotable
    {
        void Rotate(Rigidbody rigidbody);
    }
}
