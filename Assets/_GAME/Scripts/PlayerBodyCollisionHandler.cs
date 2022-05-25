using UnityEngine;
using UnityEngine.AI;

public class PlayerBodyCollisionHandler : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private PlayerStats _playerStats;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StickMan"))
        {
            if (_playerController.isSpinning) 
            {
                collision.rigidbody.AddForce(gameObject.transform.rotation.y,2,_playerController._rotateSpeed,ForceMode.Impulse);
                collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                _playerStats.pCurrentPower++;
            }
            else if (!_playerController.isSpinning)
            {
                _playerStats.pCurrentPower--;
            }
        }
    }

}
