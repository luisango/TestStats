using UnityEngine;
using System.Collections;


namespace Jellyasticity
{
    public class FireflyController : MonoBehaviour
    {
        public float m_speedX = 1.0f;
        public float m_speedY = 1.0f;
        public float m_frac = 2.0f;

        float m_minY = 5.0f;
        float m_maxY = 7.0f;
        float m_randomY;

        void Start ()
        {
            m_randomY = Random.Range(m_minY, m_maxY);
        }

        void Update ()
        {
            Vector3 pos = this.transform.position;

            float x = Mathf.Cos(Time.time / m_frac) * m_speedX * Time.deltaTime;
            float y = Mathf.Cos(Time.time / m_frac * m_randomY) * m_speedY * Time.deltaTime;
            
            this.transform.position = pos + new Vector3(x, y, 0);
        }
    }
}