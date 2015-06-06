using System.Collections.Generic;
using UnityEngine;

namespace ContarObjetos
{
    class CandyCloudController : MonoBehaviour
    {
        private float m_speedX;
        private float m_speedY;
        private float m_frac;
        private float m_randomY;

        void Start()
        {
            this.transform.Rotate(90,0,0);

            m_speedX = Random.Range(-3.0f, 3.0f);
            m_speedY = Random.Range(0.5f, 3.0f);
            m_frac = Random.Range(1.0f, 3.0f);
            m_randomY = Random.Range(5.0f, 7.0f);
        }

        void Update()
        {
            Vector3 pos = this.transform.position;
            
            float x = Mathf.Cos(Time.time / m_frac) * m_speedX * Time.deltaTime;
            float y = Mathf.Cos(Time.time / m_frac * m_randomY) * m_speedY * Time.deltaTime;
            
            this.transform.position = pos + new Vector3(x, y, 0);
        }
    }
}
