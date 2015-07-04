using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class MinigameController : Minigame.Controller
    {
        public GameObject m_candyCloudContainer;

        public GameObject[] m_objects;

        public Vector2 m_candyCloudSpawnRangeX;
        public Vector2 m_candyCloudSpawnRangeY;
        public Vector2 m_candyCloudSpawnRangeZ;

        public int m_numTotalObjects = 20;

        private int m_focusedObject;
        private int m_numObjects;

        // GETTERS & SETTERS (auxiliary methods)
        public int getNumberObjects()
        {
            return this.m_numObjects;
        }

        // MAIN METHODS
        public override void OnStart()
        {
            // Focused object the player must count
            m_focusedObject = Random.Range(0, m_objects.Length);
            GameObject ob = (GameObject)Instantiate(m_objects [m_focusedObject], new Vector3(0, 7.5f, 0), Quaternion.identity);
            ob.transform.Rotate(new Vector3(1, 0, 0), 90);
            ob.GetComponent<CandyCloudController>().enabled = false;

            // Generating differents objects with movement:
            for (int i = 0; i < m_numTotalObjects; i++)
            {
                int id = Random.Range(0, m_objects.Length);
                GameObject o = (GameObject)Instantiate(m_objects[id], new Vector3(0, 0, 0), Quaternion.identity);
                o.transform.parent = m_candyCloudContainer.transform;

                o.transform.position = new Vector3(Random.Range(m_candyCloudSpawnRangeX.x, m_candyCloudSpawnRangeX.y),
                                                   Random.Range(m_candyCloudSpawnRangeY.x, m_candyCloudSpawnRangeY.y),
                                                   Random.Range(m_candyCloudSpawnRangeZ.x, m_candyCloudSpawnRangeZ.y));

                // Updating the counter
                if (id == m_focusedObject) {
                    m_numObjects++;
                }
            }
        }

        protected override void InstantiatePlayers()
        {
            // Hardcoded spawn metrics
            Vector2 spawnRange = new Vector2(-11, 9);
            float spawnLength = spawnRange.y - spawnRange.x;
            float spawnStep = spawnLength / (Manager.Player.Instance.Get().Count * 2.2f);
            float lastSpawn = spawnRange.x;
            lastSpawn = -4.0f;

            for (int i = 0; i < Manager.Player.Instance.Get().Count; i++)
            {
                // Instantiate player
                GameObject newPlayer = InstantiatePlayer();
                //int id = Manager.Player.Instance.Get()[i].GetPuppet().GetIdentifier();
                //newPlayer = m_models[id];

                // Set position
                newPlayer.transform.position = new Vector3(lastSpawn, 0, 0);

                // Add player as a child
                newPlayer.transform.parent = this.transform;

                // Subscribe to each player
                newPlayer.GetComponent<PlayerController>().Subscribe(this);

                lastSpawn += spawnStep;
            }
        }

        public override int NormalizeScore(int score)
        {
            return score;
        }
    }
}
