using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{ 
       [RequireComponent(typeof(Rigidbody))]
internal sealed class Player : MonoBehaviour, IDamagable
{     
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private float _accelatator;
        [SerializeField] public GameObject shooterDirect;
       
        private ShootController _shootController;
        private IMove _moveTransform;
        private DamageController _damageController;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

        }


        private void Start()
        {
           _moveTransform = new AccelerationMove(_rigidbody,_speed,_accelatator);
         
            
            #region"Урок №2 Домашие Задание  1 "
            
                        
            _shootController = shooterDirect.GetComponent<ShootController>();//выносим стрельбу в отдельный класс
                      
            _damageController = new DamageController();//выносим подсчет урона в отдельный класс

            #endregion
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
            _damageController.Damaging(_hp,_playerPrefab);//выносим подсчет урона в отдельный класс
        }
    }
}


