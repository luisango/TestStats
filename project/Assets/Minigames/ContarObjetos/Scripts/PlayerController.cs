using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {

        private float m_speed = 3;
        private float m_gravity = 1;

        // Canvas puntuation:
        public Canvas canvas_Prefab;


        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();

            // Instantiate canvas to indicate num objects counted:
            Canvas canvas = (Canvas)Instantiate(canvas_Prefab, new Vector3(0, 0, 0), Quaternion.identity);
            canvas.transform.position = new Vector3(this.transform.position.x, -10,
                                                    this.transform.position.z);
            canvas.transform.FindChild("Panel").renderer.material.color = GetPlayer().GetPuppet().GetColor();
        }
        protected override void OnUpdate()
        {
            Vector3 pos = this.transform.position;
            // If player is out of platform-clouds, he falls off:
            if ((pos.x < -10) || (pos.x > 10))
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
            Vector3 gravity = new Vector3(0, -m_gravity, 0);
            //pos += gravity;

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

            // TODO: process input to count num total objects
        }

        protected override bool GameOverCheck()
        {
            return false;
        }
    }
}