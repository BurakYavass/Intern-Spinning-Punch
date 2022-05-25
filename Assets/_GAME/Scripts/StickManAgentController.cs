using UnityEngine;
using UnityEngine.AI;

public class StickManAgentController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private Transform _player;

    [SerializeField] private StickManCollisionHandler _collisionHandler;

    [SerializeField] private Animator _stickManAnim;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
       
        if (!_collisionHandler.flying)
        {
            agent.enabled = true;
            agent.SetDestination(_player.transform.position);
            _stickManAnim.SetBool("isRunning",true);
            _stickManAnim.SetBool("InAir",false);
        }
        else if (_collisionHandler.flying)
        {
            agent.enabled = false;
            _stickManAnim.SetBool("isRunning",false);
            _stickManAnim.SetBool("InAir",true);
        }
    }
    
}
