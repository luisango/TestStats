using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;

using PlayerWrapper = Player.Wrapper;


namespace ContarObjetos
{
    public class PlayerController : Player.Controller
    {
        // little interval time
        private int countUp   = 0;
        private int countDown = 0;
        public const int MAX_INTERVAL_TIME_CLICK = 8;

        // Timer params 
        public const float MAX_TIME = 15.0f; // maximum time to count objects (secs)
        private float initial_time;

        // Counting objects params
        private int number_counted_user = 0;
        private int number_objects      = 0;

        // Params puntuation user
        public int MAX_POINTS = 10;
        public int MIN_POINTS = 5;

        public GameObject m_GUIPrefab;

        protected override void OnStart()
        {
            // Obtain time startup...
            initial_time = Time.realtimeSinceStartup;

            int numPlayers     = Manager.Player.Instance.Get().Count;
            int playerPosition = 1;
            foreach (PlayerWrapper p in Manager.Player.Instance.Get())
            {
                if (GetPlayer() == p)
                    break;

                playerPosition++;
            }


            int canvasWidth = 800;
            int canvasHeight = 600;

            float canvasXStep = canvasWidth / (numPlayers + 1);
            float canvasYStep = canvasHeight / 2;



            // Number objects to count...
            number_objects = GameObject.Find("MinigameController").
                                 GetComponent<MinigameController>().getNumberObjects();

            // Vector3 pos_name = this.transform.FindChild("Name").transform.position;
            // this.transform.FindChild("Name").transform.position = new Vector3(pos_name.x - (pos_name.x*0.1f),
            //                                                                   pos_name.y - 0.3f,
            //                                                                   pos_name.z - 6.5f);
            // 
            // Vector3 pos_model = this.transform.FindChild("Model").transform.position;
            // this.transform.FindChild("Model").transform.position = new Vector3(pos_model.x,
            //                                                                    pos_model.y - 0.5f,
            //                                                                    pos_model.z - 6.5f);

            // Canvas setting to the character...
            Vector2 pos = new Vector2(canvasXStep * playerPosition, -1 * canvasYStep);
            m_GUIPrefab.GetComponent<RectTransform>().anchoredPosition = pos;


            // Name and model setting to the character...
            m_GUIPrefab.transform.FindChild("Score").FindChild("Name").GetComponent<Text>().text = GetPlayer().GetNickname();

           /* this.transform.FindChild("Canvas_Count_objects_Player").transform.position = 
                                                                   new Vector3(canvasXStep,
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
        
            */
            }


        protected override void OnUpdate()
        {
            // Reading number dialed by the user objects...
            String text = m_GUIPrefab.transform.FindChild("Score").GetComponent<Text>().text;
            number_counted_user = int.Parse(text);

            // Clear points
            SubstractScore(GetScore());

            // Updating score user...
            if (number_counted_user == number_objects) AddScore(MAX_POINTS);  // [SUCCESS        CASE]
            if ((number_counted_user > number_objects) && (number_counted_user <= number_objects+2))
                AddScore(MIN_POINTS);                                         // [MIDDLE SUCCESS CASE]
            if ((number_counted_user < number_objects) && (number_counted_user >= number_objects-2))
                AddScore(MIN_POINTS);                                         // [MIDDLE SUCCESS CASE]
                                                           // Adding nothing if  [ERROR          CASE]

            Debug.Log("Score = " + GetScore());
        }

        protected override Player.Wrapper SetPlayer()
        {
            return Manager.Minigame.Instance.GetPlayer();
        }

        protected override void ProcessInput()
        {
            countUp++;
            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Right) && countUp == MAX_INTERVAL_TIME_CLICK)
            {
                Debug.Log("Add Counter!");
                m_GUIPrefab.transform.FindChild("Score").
                     transform.FindChild("ButtonPlus").GetComponent<Button>().onClick.Invoke();
            }
            if (countUp > MAX_INTERVAL_TIME_CLICK) countUp = 0; // Adding little interval time

            countDown++;
            if (GetPlayer().GetInput().IsKeyPressed(Player.Input.Key.Left) && countDown == MAX_INTERVAL_TIME_CLICK)
            {
                Debug.Log("Substract Counter!");
                m_GUIPrefab.transform.FindChild("Score").
                     transform.FindChild("ButtonMinus").GetComponent<Button>().onClick.Invoke();
            }
            if (countDown > MAX_INTERVAL_TIME_CLICK) countDown = 0; // Adding little interval time

#if false    //  TESTING
            String text = this.transform.FindChild("Canvas_Count_objects_Player").
                                      transform.FindChild("Arrows").transform.FindChild("Text").
                                                                    GetComponent<Text>().text;

            Debug.Log("TEXT  =  " + text);
#endif
        }



        protected override bool GameOverCheck()
        {
            // The mini-game finish if:
            // 1.- The time is running out 
#if false   // TESTING
            number_objects = GameObject.Find("MinigameController").
                                 GetComponent<MinigameController>().getNumberObjects();
            Debug.Log("NUMBER OBJECTS =  " + number_objects);

            String text = this.transform.FindChild("Canvas_Count_objects_Player").
                                      transform.FindChild("Arrows").transform.FindChild("Text").
                                                                    GetComponent<Text>().text;

            number_counted_user = int.Parse(text);
            Debug.Log("TEXT CONVERT NUMBER =  " + number_counted_user);
#endif
            return ((Time.realtimeSinceStartup-initial_time) > MAX_TIME);
        }
    }
}