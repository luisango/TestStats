using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace SweetRain
{
	public class PlayerController : Player.Controller
	{
        public float m_speed = 3;
        public float m_gravity = 3.3f;

        private float m_MAX_LIMIT =  5.7f;
        private float m_MIN_LIMIT = -5.7f;

        // Params puntuation:
        public int m_initialScore = 20; // to debug
        public int m_max_score = 0;

        private float m_playTime = 30f;

        private Animator m_animator;
        private bool right;
        private bool left;
        // Aqui van los métodos que implementan la logica del
        // minijuego para el jugador.

        protected override bool GameOverCheck()
        {
           return GetScore() <= m_max_score || m_playTime <= 0;
        }

        protected override void OnStart()
        {
            m_animator = GetComponentInChildren<Animator>();

            m_animator.SetBool("walk", false);
            m_animator.SetBool("jump", false);
            m_animator.SetBool("victory", false);
            m_animator.SetBool("right", false);
            m_animator.SetBool("left", false);
            m_animator.SetBool("blow", false);

            m_speed = 3;
            m_gravity = 2.5f;
            m_initialScore = 20;
            m_max_score = 0;

            SetScore( m_initialScore );
        }

        protected override void OnUpdate()
        {
            m_playTime -= Time.deltaTime;

            Vector3 pos = this.transform.position;
            // If player is out of platform-clouds, he falls off:
            

            if (pos.x < m_MIN_LIMIT)
            {
                this.transform.position = new Vector3(m_MIN_LIMIT, transform.position.y, transform.position.z);
            }
            if (pos.x > m_MAX_LIMIT)
            {
                this.transform.position = new Vector3(m_MAX_LIMIT, transform.position.y, transform.position.z);
            }

            if ((right && left) || (!right && !left) )
            {
                m_animator.SetBool("right", false);
                m_animator.SetBool("left", false);
            }
            else if( right )
            {
                m_animator.SetBool("right", true);
            }
            else if( left )
            {
                m_animator.SetBool("left", true);
            }
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            Vector3 pos = this.transform.position;
            right = left = false;
     //       this.transform.FindChild("Model").renderer.material.color = GetPlayer().GetPuppet().GetColor();

            if (GetPlayer().GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                //this.transform.FindChild("Model").renderer.material.color = new Color(255, 0, 0);
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Right))
            {
                this.transform.position = pos + new Vector3(m_speed * Time.deltaTime, 0, 0);
                right = true;
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left))
            {
                this.transform.position = pos - new Vector3(m_speed * Time.deltaTime, 0, 0);
                left = true;
            }
        }
	}
}
