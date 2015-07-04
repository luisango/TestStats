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

        private Animator m_animator;

        protected override void OnStart()
        {
            //this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
            speed = 7;
            jumpSpeed = 16;
            gravity = 0.5f;
            currentYSpeed = 0;

            m_animator = GetComponentInChildren<Animator>();
            m_animator.SetBool("walk", false);
            m_animator.SetBool("jump", false);
            m_animator.SetBool("victory", false);
            m_animator.SetBool("right", false);
            m_animator.SetBool("left", false);
            m_animator.SetBool("blow", false);
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
                m_animator.SetBool("jump", true);

                currentYSpeed = jumpSpeed * Time.deltaTime;

                this.transform.position = new Vector3(pos.x, 0, pos.z);
            }
            else
            {
                m_animator.SetBool("jump", false);
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

            if (pos.x < -10.0f) transform.position = new Vector3(-10.0f, transform.position.y, transform.position.z);
            if (pos.x > 10.0f) transform.position = new Vector3(10.0f, transform.position.y, transform.position.z); 
        }

        protected override bool GameOverCheck()
        {
            return GetScore() >= 5;
        }
    }
}