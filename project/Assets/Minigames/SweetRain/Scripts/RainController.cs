using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SweetRain
{
    class RainController : MonoBehaviour
    {
        private float m_gravity = 1.5f;

        void Start()
        {
            // seteamos las var
        }

        void Update()
        {
            //Hacemos que se mueva
            Vector3 pos = this.transform.position;
            Vector3 gravity = new Vector3( 0, -m_gravity, 0 );

            this.transform.position = pos + gravity * Time.deltaTime;

            if ( this.transform.position.y < -1 ) Destroy( this.gameObject );
        }

        protected void OnTriggerEnter( Collider other )
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

            if ( playerController != null )
            {
                if ( playerController.GetScore() > 0 )
                    playerController.SubstractScore( 1 );

                Destroy( this.gameObject );
            } // Else: lluvia
        }
    }
}