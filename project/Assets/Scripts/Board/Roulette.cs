using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

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
        // TODO: Implement here your methods

        void Init()
        {
            m_angularAcceleration = -10.0f;
            m_angularSpeed = 0.0f;
            m_steps = 0;
            m_maxNumber = 6.0f;
            m_fractions = 360.0f / m_maxNumber;
            m_isRotating = false;
        }

        void Update()
        {
            if ( !m_isRotating )
            {
                return;
            }

            if (m_angularSpeed > 0)
            {
                transform.Rotate(transform.up, m_angularSpeed * Time.deltaTime);
                m_angularSpeed += m_angularAcceleration * Time.deltaTime;
            }
            else
            {
                float currentRot = transform.rotation.eulerAngles.y;

                for( int index = 0; index < m_maxNumber; index++ )
                {
                    if( index * m_fractions <= currentRot && (index + 1) * m_fractions > currentRot )
                    {
                        m_isRotating = false;
                        m_steps = index + 1;
                        return;
                    }
                }
            }
        }

        public void TurnRoulette(float angularSpeed)
        {
            m_angularSpeed = angularSpeed;
            m_isRotating = true;
        }

        public int GetSteps( out bool isFinish )
        {
            isFinish = !m_isRotating;
            return m_steps;
        }
    }
}