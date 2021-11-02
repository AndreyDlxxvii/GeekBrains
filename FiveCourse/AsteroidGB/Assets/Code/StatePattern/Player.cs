using System;
using UnityEngine;

namespace AsteroidGB
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject Bullet;
        [SerializeField] private GameObject GunPoint;
        private Rigidbody _rb;
        private StateMachine _stateMachine;
        public PlayerMove PlayerMove;
        public PlayerStay PlayerStay;
        
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            _stateMachine = new StateMachine();
            PlayerStay = new PlayerStay(this, _stateMachine);
            PlayerMove = new PlayerMove(this, _stateMachine);
            _stateMachine.Init(PlayerStay);
        }

        void Update()
        {
            _stateMachine.CurrentState.OnUpdate();
        }

        private void FixedUpdate()
        {
            _stateMachine.CurrentState.OnFixedUpdate();   
        }

        public void RotateShip()
        {
            Vector3 rot = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotate = Mathf.Atan2(rot.y, rot.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f,0f,rotate);
        }
        public void Movement(float moveHorizontal, float moveVertical)
        {
            _rb.AddForce(Vector3.up.normalized * moveVertical);
            _rb.AddForce(Vector3.right.normalized * moveHorizontal);
        }
        public void StopMovement()
        {
            _rb.velocity = Vector3.zero;
        }
    }
}