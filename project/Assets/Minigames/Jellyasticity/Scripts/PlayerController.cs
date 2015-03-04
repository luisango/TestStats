using UnityEngine;
using System.Collections;


namespace Jellyasticity
{
    public class PlayerController : Player.Controller
    {
        public ParticleSystem m_hitParticle;


        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();
        }
        protected override void OnUpdate()
        {
            // if (Time.realtimeSinceStartup < 50)
            //    SendEvent((int)CutLogs.MinigameController.CustomEvents.RockTime);
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            this.transform.FindChild("Model").renderer.material.color = GetPlayer().GetPuppet().GetColor();

            if (GetPlayer().GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                this.transform.FindChild("Model").renderer.material.color = new Color(255, 0, 0);
                Hit();
            }
        }

        protected override bool GameOverCheck()
        {
            return GetScore() >= 5;
        }

        private void Hit()
        {
            m_hitParticle.Emit(1);
            AddScore(1);
        }
    }
}