using System.Collections.Generic;
using UnityEngine;

namespace ContarObjetos
{
    class CandyCloudController : MonoBehaviour
    {
        private float m_speed;
        private float m_speedFact;

        void Start()
        {
            float random =  Random.Range(-1, 1); 
           // m_speedFact =  random == 0.0f ? 2.5f : random * 10.0f;
            m_speedFact = 0;
            // seteamos las var
        }

        void Update()
        {
            //Hacemos que se mueva
            m_speed = Mathf.Sin(Time.time) * m_speedFact;
            Vector3 pos = this.transform.position;
            Vector3 move = new Vector3(m_speed, 0, 0);

            this.transform.position = pos + move * Time.deltaTime;
        }
    }
}
