using UnityEngine;
using System.Collections;


namespace CutLogs
{
    public class PlayerController : Player.Controller
    {
        public ParticleSystem m_hitParticle;

        public int increase = 50; // increase to gum

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
            //this.transform.FindChild("chicle").renderer.material.color = GetPlayer().GetPuppet().GetColor(); 

            if (GetPlayer().GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                this.transform.FindChild("Model").renderer.material.color = new Color(255, 0, 0);
                Hit();
            }
        }

        protected override bool GameOverCheck()
        {
            return GetScore() >= 20;
        }

        private void Hit()
        {
            // Inflar el chicle!
            Vector3 position = this.transform.FindChild("chicle").localScale;
            this.transform.FindChild("chicle").localScale = new Vector3(position.x + Time.deltaTime * increase,
                                                                        position.y + Time.deltaTime * increase,
                                                                        position.z + Time.deltaTime * increase);

            // Efects
            m_hitParticle.Emit(1);

            // Logic points
            AddScore(1);
        }
    }
}