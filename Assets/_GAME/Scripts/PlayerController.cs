using System;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _vSpeed;
    [SerializeField] private float _hSpeed;
    [SerializeField] public float _rotateSpeed;
   
    [SerializeField]private GameObject _playerBody;
    [SerializeField] private PlayerStats _playerStats;
    
    private Vector3 firstPos, endPos;

    public bool isSpinning = false;
    
    void Start()
    {
        DOTween.Init();

    }

    void OnEnable()
    {
        GameManager.OnRunning += GameStart ;
    }

    void OnDisable()
    {
        GameManager.OnRunning -= GameStart;
    }
    
    public void SpeedChanger(float rotatespeed,float horizontalspeed,int vspeed)
    {
        _rotateSpeed = rotatespeed;
        _hSpeed = horizontalspeed;
        _vSpeed = vspeed;
    }
    

    void GameStart()
    {
        transform.position += Vector3.forward * _vSpeed * Time.deltaTime;
        
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -8f, 8f);
        transform.position = clampedPosition;

        MousePosition();
    }

    void MousePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
            isSpinning = true;
            _playerBody.transform.DOKill();
            
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;
            
            float xDiff = endPos.x - firstPos.x;
            transform.Translate(xDiff*Time.deltaTime * _hSpeed/100, 0, 0);
            
            PlayerBodyRotate();

        }
        if(Input.GetMouseButtonUp(0))
        {
            _playerBody.transform.DOKill();

            isSpinning = false;

            firstPos = Vector3.zero;
            endPos = Vector3.zero;
        }
        else if (!Input.GetMouseButton(0))
        {
            _playerBody.transform.DOKill();
            _playerBody.transform.localRotation = Quaternion.Euler(0f,0f,0f);
        }

    }

    void PlayerBodyRotate()
    {
        if (_playerStats.pCurrentPower >= 1f)
        {
            _playerBody.transform.DOKill();
            _playerBody.transform.DOLocalRotate(new Vector3(0, -360, 0), 0.5f*_rotateSpeed,RotateMode.FastBeyond360).SetLoops(-1,LoopType.Restart).SetEase(Ease.Linear);
        }
        else
        {
            _playerBody.transform.localRotation = Quaternion.Euler(0f,0f,0f);
        }
    }

    
}
