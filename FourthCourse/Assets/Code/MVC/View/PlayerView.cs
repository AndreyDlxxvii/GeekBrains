using UnityEngine;

namespace CodeGeek
{
    public class PlayerView : MonoBehaviour
    {
        private Rigidbody _rb;
        private byte _countCheckGround;
        
        public delegate void GetCoins();
        public event GetCoins GetCoin;

        public delegate void GameOver();
        public event GameOver MyGameOver;
        

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move(float speed)
        {
            _rb.AddForce(new Vector3(Input.GetAxis(AxisManager.Horizontal), 0.0f, Input.GetAxis(AxisManager.Vertical)).normalized * speed);
            if (transform.position.y < -18f)
            {
                MyGameOver?.Invoke();
            }
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
            if (other.GetComponent<CoinView>())
            {
                GetCoin?.Invoke();
                Destroy(other.gameObject);
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