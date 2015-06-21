using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {
        // little retardation time
        private int countUp   = 0;
        private int countDown = 0;

        private const int MAX_TIME = 10;

        protected override void OnStart()
        {
            // Name and model setting to the character...
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

            this.transform.FindChild("Canvas_Count_objects_Player").transform.FindChild("Text").
                                                                    GetComponent<Text>().color = GetPlayer().GetPuppet().GetColor();
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
            countUp++;
            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Right) && countUp == MAX_TIME)
            {
                Debug.Log("Add Counter!");
                this.transform.FindChild("Canvas_Count_objects_Player").
                     transform.FindChild("Arrows").
                     transform.FindChild("ButtonUp").GetComponent<Button>().onClick.Invoke();
            }
            if (countUp > MAX_TIME) countUp = 0; // Adding little retardation

            countDown++;
            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left) && countDown == MAX_TIME)
            {
                Debug.Log("Substract Counter!");
                this.transform.FindChild("Canvas_Count_objects_Player").
                     transform.FindChild("Arrows").
                     transform.FindChild("ButtonDown").GetComponent<Button>().onClick.Invoke();
            }
            if (countDown > MAX_TIME) countDown = 0; // Adding little retardation
        }

        protected override bool GameOverCheck()
        {
            return false;
        }
    }
}