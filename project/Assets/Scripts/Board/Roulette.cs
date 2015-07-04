﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using PlayerWrapper = Player.Wrapper;

namespace Board
{
   	class Roulette : MonoBehaviour
    {
        public float m_angularAcceleration;
        public float m_angularSpeed;
        public int  m_steps;
        public float m_maxNumber;
        public float m_fractions;
        public bool m_isRotating;
        public bool m_isInitialized;
        // TODO: Implement here your methods

        void Init()
        {
            m_angularAcceleration = -5.0f;
            m_angularSpeed = 0.0f;
            m_steps = 0;
            m_maxNumber = 6.0f;
            m_fractions = 360.0f / m_maxNumber;
            m_isRotating = false;
            m_isInitialized = true;

            Debug.Log("SE PUTO INICIA RULETA");
        }

        void Update()   
        {
            if (!m_isInitialized)
                Init();

            for (int index = 0; index < 2; index++)
            {
                
                Debug.DrawLine(transform.position, transform.position  + Quaternion.Euler( 0,0, index * m_fractions ) *  transform.up * 100.0f, Color.black );
            }



            if (!m_isRotating)
                return;

            if (m_angularSpeed > 0)
            {
                transform.Rotate(transform.forward, m_angularSpeed * Time.deltaTime);
                m_angularSpeed += m_angularAcceleration * Time.deltaTime;
            }
            else
            {
                float currentRot = transform.rotation.eulerAngles.z;

                for( int index = 0; index < m_maxNumber; index++ )
                {
                    if( index * m_fractions <= currentRot && (index + 1) * m_fractions > currentRot )
                    {
                        m_isRotating = false;
                        m_steps = ( int )Mathf.Repeat( index + 2, m_maxNumber + 1 );

                        if (m_steps == 0) m_steps = 1;

                        return;
                    }
                }
            }
        }

        public void TurnRoulette(float angularSpeed)
        {
            m_angularSpeed = angularSpeed * UnityEngine.Random.Range( 0.01f, 1.0f );
            m_isRotating = true;
        }

        public bool GetSteps( out int steps )
        {
            steps = m_steps;
            return !m_isRotating;
        }

    }
}