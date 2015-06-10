using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SweetRain
{
    // Description: class that implements the functionality of 
    // sweet rain (bonus or penalty points)
	class RainController : MonoBehaviour
	{
        public float m_gravity = 1.5f;
        public int m_bonus = 1;

        void Start()
        {
            // seteamos las var
        }

        void Update()
        {
            //Hacemos que se mueva
            Vector3 pos = this.transform.position;
            Vector3 gravity = new Vector3(0, -m_gravity, 0);

            this.transform.position = pos + gravity * Time.deltaTime;

            if (this.transform.position.y < -1) Destroy(this.gameObject);
        }

        protected void OnTriggerEnter(Collider other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if (playerController != null) {
                // Logica de puntos
                // To debug
                if ((playerController.GetScore() < playerController.m_max_score) ||
                     (playerController.score < playerController.m_max_score))
                     {
                         playerController.AddScore(m_bonus);
                         playerController.score += m_bonus;
                      }
                }

            //if (playerController.GetScore() < playerController.m_max_score)
            //    playerController.AddScore(m_bonus);  

            Debug.Log("Player: "+ playerController.name+" Score: "+ playerController.score);

            // Se destruye la gota de galleta
            Destroy(this.gameObject);
        } // Else: lluvia

        // It allows you to modify the amount of bonus or penalty
        public void SetModifierPoints(int value)
        {
            m_bonus = value;
        }
    }
}
