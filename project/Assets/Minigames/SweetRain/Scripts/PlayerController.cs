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

        private float m_MAX_LIMIT =  6;
        private float m_MIN_LIMIT = -6;

        // Params puntuation:
        public int score = 0; // to debug
        public int m_max_score = 20;

        // Aqui van los métodos que implementan la logica del
        // minijuego para el jugador.

        protected override bool GameOverCheck()
        {
            return GetScore() >= m_max_score;
        }

        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
        }

        protected override void OnUpdate()
        {
            Vector3 pos = this.transform.position;
            // If player is out of platform-clouds, he falls off:
            if ((pos.x < m_MIN_LIMIT) || (pos.x > m_MAX_LIMIT))
            {
                Vector3 gravity = new Vector3(0, -m_gravity, 0);
                this.transform.position = pos + gravity * Time.deltaTime;
            }
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            Vector3 pos = this.transform.position;

            this.transform.FindChild("Model").renderer.material.color = GetPlayer().GetPuppet().GetColor();

            if (GetPlayer().GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                this.transform.FindChild("Model").renderer.material.color = new Color(255, 0, 0);
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Right))
            {
                //Debug.Log("Right!");
                this.transform.position = pos + new Vector3(m_speed * Time.deltaTime, 0, 0);
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left))
            {
                //Debug.Log("Left!");
                this.transform.position = pos - new Vector3(m_speed * Time.deltaTime, 0, 0);
            }
        }
	}
}
