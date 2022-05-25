using UnityEngine;

public class P_Anim_ParticleController : MonoBehaviour
{
    [SerializeField] private PlayerCollisionHandler _playerCollisionHandler;

    [SerializeField] private PlayerController _playerController;

    [SerializeField] private ParticleSystem runParticle,spinParticle,feetParticle ;
    
    [SerializeField] private Animator _animator;

    private bool _spinEnable;

    void Update()
    {
        if (_playerCollisionHandler.falling)
        {
            _animator.SetBool("Falling",true);
            _animator.SetBool("isRunning",false);
            runParticle.Stop(true);
            spinParticle.Stop(true);
            feetParticle.Stop(true);
            
        }
        else if (!_playerCollisionHandler.falling)
        {
            _animator.SetBool("Falling",false);
            _animator.SetBool("isRunning",true);
        }
        
        if (_playerController.isSpinning)
        {
            spinParticle.transform.position = _playerController.transform.position;
            feetParticle.enableEmission = true;
            runParticle.enableEmission = false;
            _animator.SetBool("Falling",false);
            _animator.SetBool("isRunning",false);
        }
        else if(!_playerController.isSpinning)
        {
            spinParticle.transform.position = new Vector3(0, -1000, 0);
            spinParticle.enableEmission = false;
            runParticle.enableEmission= true;
            feetParticle.enableEmission = false;
        }
    }
}
