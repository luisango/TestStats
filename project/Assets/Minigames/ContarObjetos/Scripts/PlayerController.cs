using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {
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
            //TODO: read number dialed by the user objects
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            //TODO: process input to count num total objects
        }

        protected override bool GameOverCheck()
        {
            return false;
        }
    }
}