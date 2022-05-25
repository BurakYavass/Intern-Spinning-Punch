using UnityEngine;

    public class PlayerCollisionHandler : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private PlayerStats _playerStats;
        [SerializeField] private PlayerStatUi _playerStatUI;
        [SerializeField] private Rigidbody _rb;

        public bool falling = false;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
               
                _playerController.SpeedChanger(rotatespeed:1,horizontalspeed:2,vspeed:15);
                falling = false;
                EnableRagdoll();
            }
        }
        
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Hole"))
            {
                _playerController.SpeedChanger(rotatespeed:0,horizontalspeed:0,vspeed:0);
                falling = true;
                DisableRagdoll();
                _playerStatUI.PlayerUIControl(false);
            }
            
            if (other.gameObject.CompareTag("Wall"))
            {
                _playerStats.pCurrentPower -= 10;
                other.gameObject.SetActive(false);
            }
            
            if (other.gameObject.CompareTag("Potion"))
            {
                _playerStats.CurrentPowerChanger(10);
                other.gameObject.SetActive(false);
            }
        }
        
        void EnableRagdoll()
        {
            _rb.isKinematic = false;
            _rb.detectCollisions = true;
        }
        
        void DisableRagdoll()
        {
            _rb.isKinematic = true;
            _rb.detectCollisions = false;
        }
    }

