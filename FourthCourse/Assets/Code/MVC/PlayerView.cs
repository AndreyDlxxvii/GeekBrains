using System;
using UnityEngine;

namespace GeekBrainsHW.MVC
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rb;
        private byte _countCheckGround;
        
        public delegate void GetCoins();
        public event GetCoins GetCoin;

        public delegate void MyGameOver();
        public event MyGameOver GameOver;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move(float speed)
        {
            _rb.AddForce(new Vector3(Input.GetAxis(AxisManager.Horizontal), 0.0f, Input.GetAxis(AxisManager.Vertical)).normalized * speed);
        }

        public void Jump(float _jumpForce)
        {
            if (Input.GetAxis(AxisManager.Jump) > 0 && _countCheckGround > 0)
            {
                _rb.AddForce(Vector3.up * _jumpForce);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<DestroyCoin>())
            {
                GetCoin?.Invoke();
            }
        }

        void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _countCheckGround++;
        } 
        //check out ground
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _countCheckGround--;
        }
    }
}