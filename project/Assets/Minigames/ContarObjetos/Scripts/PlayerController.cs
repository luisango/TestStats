using UnityEngine;
using System.Collections;
using UnityEngine.UI;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {
        // Canvas puntuation:
        // public Canvas canvas_Prefab;


        protected override void OnStart()
        {
            this.transform.FindChild("Name").GetComponent<TextMesh>().text = GetPlayer().GetNickname();

            Vector3 pos_name = this.transform.FindChild("Name").transform.position;
            this.transform.FindChild("Name").transform.position = new Vector3(pos_name.x - (pos_name.x*0.1f),
                                                                              pos_name.y - 0.3f,
                                                                              pos_name.z - 6.5f);

            Vector3 pos_model = this.transform.FindChild("Model").transform.position;
            this.transform.FindChild("Model").transform.position = new Vector3(pos_model.x,
                                                                               pos_model.y - 0.5f,
                                                                               pos_model.z - 6.5f);
            // Canvas setting to the character...
            this.transform.FindChild("Canvas_Count_objects_Player").transform.position = 
                                                                       new Vector3(pos_model.x,
                                                                                   pos_model.y,
                                                                                   pos_model.z);

            this.transform.FindChild("Canvas_Count_objects_Player").
                                      transform.FindChild("Arrows").
                                      transform.position = new Vector3(pos_model.x*(-128.0f)-50,
                                                                       pos_model.y-280,
                                                                       pos_model.z);


            this.transform.FindChild("Canvas_Count_objects_Player").
                                      transform.FindChild("Text").
                                      transform.position = new Vector3(pos_model.x * (-128.0f) - 50,
                                                                       pos_model.y - 200,
                                                                       pos_model.z);

            this.transform.FindChild("Canvas_Count_objects_Player").transform.FindChild("Text").
                                                                    GetComponent<Text>().text = GetPlayer().GetNickname();
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