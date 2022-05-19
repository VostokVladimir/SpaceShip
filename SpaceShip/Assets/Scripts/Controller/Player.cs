using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{ 
internal sealed class Player : MonoBehaviour, IDamagable

{     
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private   Rigidbody2D _bullet;
        [SerializeField] private   Transform _barrel;
        [SerializeField] private   float _force;
        [SerializeField] private GameObject _playePrefab;
        [SerializeField] private float _accelatator;


        private ShootController _shootController;
        private IMove _moveTransform;
        private DamageController _damageController;

        private void Start()
        {
            _moveTransform = new AccelerationMove(transform,_speed,_accelatator);
            _shootController = new ShootController(_bullet,_barrel,_force);
            _damageController = new DamageController();

        }

        private void Update()
        {

            _moveTransform.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
          
            if (Input.GetButtonDown("Fire1"))
            {
                _shootController.Shooting();
            }
            if(Input.GetKeyDown(KeyCode.LeftShift))
            { 
                 if (_moveTransform is AccelerationMove accelerationMove)
                   {
                    accelerationMove.AddAcceleration();
                   }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (_moveTransform is AccelerationMove accelerationMove)
                {
                    accelerationMove.RemoveAcceleration();
                }
            }

        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            _damageController.Damaging(_hp,_playePrefab);
        }
    }
}


