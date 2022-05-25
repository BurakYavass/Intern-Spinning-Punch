using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public delegate void ClickAction();
        public static event ClickAction OnIdle;
        public static event ClickAction OnRunning;
        private enum State
        {
            Idle,
            Running,
        }

        private State _state;
        void Start()
        {
           _state = State.Idle;
        }
        
        void Update()
        {
            switch (_state)
            {
                case State.Idle:
                    if (OnIdle != null) 
                        OnIdle();
                    if (Input.GetMouseButtonUp(0))
                    {
                        _state = State.Running;
                    }
                    break;
                
                case State.Running:
                    if (OnRunning != null)
                        OnRunning();
                    break;
                
            }
        
        }
    }

