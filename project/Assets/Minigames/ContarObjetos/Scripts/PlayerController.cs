using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {
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
            this.transform.FindChild("Model").renderer.material.color = GetPlayer().GetPuppet().GetColor();

            if (GetPlayer().GetInput().IsKeyDown(Player.Input.Key.Action))
            {
                this.transform.FindChild("Model").renderer.material.color = new Color(255, 0, 0);
            }
        }

        protected override bool GameOverCheck()
        {
            return false;
        }
    }
}