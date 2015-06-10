using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SweetRain
{
    // Description: class that implements the functionality of the bad 
    // or acid rain (penalty points)
    class BadRainController : MonoBehaviour
	{
        public float m_gravity = 1.5f;

        // Params puntuation:
        public int m_penalty = 1;

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
                if ((playerController.GetScore() > 0)||
                     (playerController.score      > 0))
                     {
                         playerController.SubstractScore(m_penalty);
                           playerController.score--;
                      }
                }

                //if (playerController.GetScore() > 0)
            //    playerController.SubstractScore(m_penalty);  // Penalty points

            Debug.Log("ACID RAIN!");
            Debug.Log("Player: "+ playerController.name+" Score: "+ playerController.score);
                
            // Se destruye la gota de galleta
            Destroy(this.gameObject);
        } // Else: lluvia

        // It allows you to modify the amount of penalty
        public void SetModifierPoints(int value)
        {
            m_penalty = value;
        }
     }
}



