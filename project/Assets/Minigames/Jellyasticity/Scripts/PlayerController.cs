using UnityEngine;
using System.Collections;


namespace Jellyasticity
{
    public class PlayerController : Player.Controller
    {
        public float speed;
        public float jumpSpeed;
        public float gravity;
        public float currentYSpeed;


        protected override void OnStart()
        {
            //this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
            speed = 7;
            jumpSpeed = 16;
            gravity = 0.5f;
            currentYSpeed = 0;
        }
        protected override void OnUpdate()
        {
            // if (Time.realtimeSinceStartup < 50)
            //    SendEvent((int)CutLogs.MinigameController.CustomEvents.RockTime);

            // Process custom gravity
            Vector3 pos = this.transform.position;

            // El suelo
            if (pos.y <= 0)
            {
                currentYSpeed = jumpSpeed * Time.deltaTime;

                this.transform.position = new Vector3(pos.x, 0, pos.z);
            }


            currentYSpeed -= gravity * Time.deltaTime;
            this.transform.position = pos + new Vector3(0, currentYSpeed, 0);
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            Vector3 pos     = this.transform.position;
            Transform model = this.transform.FindChild("Model");

            //model.renderer.material.color = GetPlayer().GetPuppet().GetColor();

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left))
            {
                //model.renderer.material.color = new Color(255, 0, 0);
                this.transform.position = pos - new Vector3(speed * Time.deltaTime, 0, 0);
            }

            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Right))
            {
                //model.renderer.material.color = new Color(255, 0, 0);
                this.transform.position = pos + new Vector3(speed * Time.deltaTime, 0, 0);
            }
        }

        protected override bool GameOverCheck()
        {
            return GetScore() >= 5;
        }
    }
}