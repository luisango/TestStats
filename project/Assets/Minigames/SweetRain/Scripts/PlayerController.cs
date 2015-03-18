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
