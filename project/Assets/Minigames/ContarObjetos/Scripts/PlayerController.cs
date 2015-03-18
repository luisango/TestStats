using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {

        private float m_speed = 3;
        private float m_gravity = 1;

        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
        }
        protected override void OnUpdate()
        {

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
        }

        protected override bool GameOverCheck()
        {
            return false;
        }
    }
}