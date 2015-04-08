using System.Collections.Generic;
using UnityEngine;

namespace ContarObjetos
{
    class CandyCloudController : MonoBehaviour
    {
        private float m_speedX, m_speedY;
        private float m_speedFactX, m_speedFactY;
        private Vector3 initial_pos;

        void Start()
        {
            int random =  Random.Range(-5, 5); // Range of velocities to the axis X
            m_speedFactX =  random == 0.0f ? 1.5f : random * 6.0f;

            Debug.Log("Name gamObject: " + this.gameObject.name + " \n "); ;

            this.transform.Rotate(90,0,0);

            Debug.Log("random: " + random + " \n ");

            switch (random)
            {
                case -5: m_speedFactX = 0.5f; break;
                case -4: m_speedFactX = 1.0f; break;
                case -3: m_speedFactX = 1.2f; break;
                case -2: m_speedFactX = 1.5f; break;
                case -1: m_speedFactX = 1.7f; break;
                case 0: m_speedFactX = 2.0f; break;
                case 1: m_speedFactX = 2.5f; break;
                case 2: m_speedFactX = 2.7f; break;
                case 3: m_speedFactX = 3.0f; break;
                case 4: m_speedFactX = 3.5f; break;
                case 5: m_speedFactX = 4.0f; break;
            }

            Debug.Log("m_speedFactX: " + m_speedFactX + " \n ");

            m_speedFactY = random == 0.0f ? 2.5f : random * 10.0f;
            initial_pos = this.transform.position;
            // m_speedFact = 0;
            // seteamos las var
        }

        void Update()
        {
            //Hacemos que se mueva
            // Set up velocities
            if ((m_speedFactX >= 0.5f) && (m_speedFactX <= 1.0f))
            {
                m_speedX = 0.5f + 0.5f * Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 1.0f) && (m_speedFactX <= 1.2f))
            {
                m_speedX = 0.7f + 0.7f * Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 1.2f) && (m_speedFactX <= 1.5f))
            {
                m_speedX = 0.8f + 0.8f * Mathf.Cos(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 1.5f) && (m_speedFactX <= 1.7f))
            {
                m_speedX = 0.9f + 1.0f * Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 1.7f) && (m_speedFactX <= 2.0f))//****
            {
                m_speedX = Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 2.0f) && (m_speedFactX <= 2.5f))
            {
                m_speedX = 1.0f * Mathf.Cos(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 2.5f) && (m_speedFactX <= 2.7f))//***
            {
                m_speedX = 0.9f + Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 2.7f) && (m_speedFactX <= 3.0f))
            {
                m_speedX = 0.9f + 2.0f * Mathf.Cos(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 3.0f) && (m_speedFactX <= 3.5f))
            {
                m_speedX = 2.0f + Mathf.Sin(Time.time) * m_speedFactX;
            }
            if ((m_speedFactX > 3.5f) && (m_speedFactX <= 4.0f))
            {
                m_speedX = 2*Mathf.Cos(Time.time) * m_speedFactX;
            }

            Vector3 pos = this.transform.position;
            Debug.Log("Pos: " + pos + " \n ");
            

            if ((pos.x >= 7.0f)||(pos.x <= -7.0f))
            {
                float random = Random.Range(-1, 1);
                pos.x = random == 0.0f ? 1.5f : random * 6.0f;
  
            }
            
            Vector3 move = new Vector3(m_speedX, 0, 0);

            this.transform.position = pos + move * Time.deltaTime;

        }
    }
}
