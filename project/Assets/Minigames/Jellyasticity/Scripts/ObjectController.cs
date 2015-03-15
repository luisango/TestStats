using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Jellyasticity
{
	class ObjectController : MonoBehaviour
	{

        protected void OnTriggerEnter(Collider other)
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if (playerController != null) {
                // Logica de puntos
                /*if ((playerController.GetScore() > 0)||(playerController.score > 0)){ playerController.SubstractScore(1);
                playerController.score--;
                }*/ // To debug
                playerController.AddScore(1);

                //Debug.Log("Player: "+ playerController.name+" Score: "+ playerController.score);
                // Se destruye la gota de galleta
                Destroy(this.gameObject);
            } // Else: lluvia
        }

	}
}
