using System;
using static UnityEngine.Debug;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace GeekBrainsHW
{
    internal sealed class Player : MonoBehaviour
    {
        private GameManager _gameManager;
        private float _speed = 5f;
        private float _jumpForce = 100f;
        private bool _isGrounded;
        private Rigidbody _rb;
        private byte _countCheckGround;
        private bool _immortalBonus = false;
        private float _myTimer;
        private Dictionary<string, Action> _myActions;
        private ImmortalBonus _myTrigger;
     

        void Start()
        {
            _rb = GetComponent<Rigidbody>();
            _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
            GetUpBonus();
        }

        private void GetUpBonus()
        {
            _myTrigger = FindObjectOfType<ImmortalBonus>();
            _myTrigger.OnTrigger += b => { _immortalBonus = b;};
        }

        void Update()
        {
            MyTimer();
        }

        private void MyTimer()
        {
            if (_immortalBonus)
            {
                _myTimer += Time.deltaTime;
                if (_myTimer>5f)
                {
                    _immortalBonus = false;
                    _myTimer = 0f;
                    if (_myTrigger is { }) _myTrigger.OnTrigger -= n => { };
                }
            }
        }

        void FixedUpdate()
        {
            Movement();
            Jump();
        }
    
        private void Movement()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            _rb.AddForce(movement.normalized * _speed);
            if (transform.position.y < -18f && !_immortalBonus)
            {
                _gameManager.CheckGameOver();
            }
            else if (transform.position.y < -18f && _immortalBonus)
            {
                transform.position = new Vector3(-5f,-16.7f,37f);
            }
        }
    
        private void Jump()
        {
            if (Input.GetAxis("Jump") > 0 && _countCheckGround>0)
            {
                _rb.AddForce(Vector3.up * _jumpForce);
            }
        }
        //check on ground
        void OnCollisionEnter (Collision collision)
            {
                if (collision.gameObject.CompareTag("Ground")) _countCheckGround++;
            } 
        //check out ground
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _countCheckGround--;
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            OnTriggered(other.gameObject.tag);
        }

        private void OnTriggered(string value)
        {
            _myActions = new Dictionary<string, Action>();
            _myActions["Coin"] = _gameManager.IncrementalScore;
            _myActions["Finish"] = _gameManager.Finish;
            if (_myActions.ContainsKey(value)) _myActions[value]();
        }
        
    }
}


