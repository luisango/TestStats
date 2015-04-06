using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace SweetRain
{
	public class PlayerController : Player.Controller
	{
        private float m_speed = 3;
        private float m_gravity = 2.5f;

        //public int score = 20; // to debug

        // Aqui van los métodos que implementan la logica del
        // minijuego para el jugador.

        protected override bool GameOverCheck()
        {
            return GetScore() >= 20;
        }

        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
        }

        protected override void OnUpdate()
        {
            Vector3 pos = this.transform.position;
            // If player is out of platform-clouds, he falls off:
            if ((pos.x < -4) || (pos.x > 5))
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
                Debug.Log("Right!");
                this.transform.position = pos + new Vector3(m_speed * Time.deltaTime, 0, 0);
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left))
            {
                Debug.Log("Left!");
                this.transform.position = pos - new Vector3(m_speed * Time.deltaTime, 0, 0);
            }
        }
	}
}
