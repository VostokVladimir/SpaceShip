using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Asteroids
{
    [System.Serializable]
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
        internal SpaceBoundary spaceBoundary;


        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            spaceBoundary = new SpaceBoundary();
            GetSpaceBoundary(ref spaceBoundary);

        }

        private SpaceBoundary GetSpaceBoundary(ref SpaceBoundary spaceBoundary)
        {
            
            spaceBoundary.x_min = -8.54f;
            spaceBoundary.x_max = 1.6f;
            spaceBoundary.y_min = 1.0f;
            spaceBoundary.y_max = 2.0f;
            
            return spaceBoundary;
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

        private void FixedUpdate()
        {
            _rigidbody.position=new Vector3
                (
                  Mathf.Clamp(_rigidbody.position.x, spaceBoundary.x_min, spaceBoundary.x_max),
                  Mathf.Clamp(_rigidbody.position.y, spaceBoundary.y_min, spaceBoundary.y_max),
                  0.0f

                );
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _damageController.Damaging(_hp,_playerPrefab);//выносим подсчет урона в отдельный класс
        }

        #region "практика лямбда не открывать"
        string s;

        public string GetSS()
        {
            return s;
        }
        public string GetS() => s;

        IEnumerator T()
        {
            yield return new WaitUntil(()  =>  true) ;
        }



        public Action<string, int> greet;
        public void Run()
        {

            greet += Action1;



            greet += Test;
            greet += (s, i) => 
            { 
                Debug.Log(s); 
            };

            greet?.Invoke("TTTT", 5);

            /* greet += name =>
             {
                 Test();
                 string greeting = $"Hello {name}!";
                 Console.WriteLine(greeting);
             };

            if(true) greet += name => */
        }

        public void Test(string s, int i)
        {
            //пусто
            Debug.Log(s);
        }


        public void Action1(string s, int i)
        {
            //много
        }

        public void Action2()
        {
            //много
        }
        #endregion

    }
}


