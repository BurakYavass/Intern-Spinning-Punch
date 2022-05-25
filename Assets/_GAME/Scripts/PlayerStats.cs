using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PlayerStats : MonoBehaviour
    {
        public int pTotalPower = 100;
        public int pDefPower = 50;
        public int pCurrentPower;
        void Start()
        {
            pCurrentPower = pDefPower;
        }

        private void Update()
        {
            int currentClamp = pCurrentPower;
            currentClamp = Mathf.Clamp(currentClamp, 0, 100);
            pCurrentPower = currentClamp;
        }

        public void CurrentPowerChanger(int buff)
        {
            pCurrentPower += buff;
        }
        
    }
