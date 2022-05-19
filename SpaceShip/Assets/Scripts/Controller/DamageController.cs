using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Asteroids
{
    public class DamageController:MonoBehaviour
    {
        public float hp;
        public GameObject game_Object;

       

        public void Damaging(float hp, GameObject game_Object)
        {
            if (game_Object is IDamagable)
            {
                if (hp <= 0)
                {
                    //Destroy(game_Object);
                    gameObject.SetActive(false);//как это реализовать что бы не не использовать монобихэвиор
                }
                else
                {
                    hp--;
                }
            }
            else { return; }
        }
    }
}
