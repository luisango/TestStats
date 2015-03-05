using UnityEngine;
using System.Collections;


namespace ContarObjetos
{
    public class MinigameController : Minigame.Controller
    {
        public GameObject m_candyCloudContainer;
        public GameObject m_candyCloudPrefab;
        public Vector2 m_candyCloudSpawnRangeX;
        public Vector2 m_candyCloudSpawnRangeY;
        public Vector2 m_candyCloudSpawnRangeZ;
        private static int m_minCandyClouds = 5;
        private static int m_maxCandyClouds = 15;

        public override void OnStart()
        {
            int m_numCandyClouds = Random.Range(m_minCandyClouds, m_maxCandyClouds);
            for (int i = 0; i < m_numCandyClouds; i++) {
                InstantiateCandyCloud();
            }
        }

        protected void InstantiateCandyCloud()
        {
            GameObject o = (GameObject)Instantiate(m_candyCloudPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            o.transform.parent = m_candyCloudContainer.transform;

            o.transform.position = new Vector3(Random.Range(m_candyCloudSpawnRangeX.x, m_candyCloudSpawnRangeX.y),
                Random.Range(m_candyCloudSpawnRangeY.x, m_candyCloudSpawnRangeY.y),
                Random.Range(m_candyCloudSpawnRangeZ.x, m_candyCloudSpawnRangeZ.y));
        }

        protected override void InstantiatePlayers()
        {
            // Hardcoded spawn metrics
            Vector2 spawnRange = new Vector2(-11, 9);
            float spawnLength = spawnRange.y - spawnRange.x;
            float spawnStep = spawnLength / (Manager.Player.Instance.Get().Count * 2);
            float lastSpawn = spawnRange.x;

            for (int i = 0; i < Manager.Player.Instance.Get().Count; i++)
            {
                lastSpawn += spawnStep;

                // Instantiate player
                GameObject newPlayer = InstantiatePlayer();

                // Set positoin
                newPlayer.transform.position = new Vector3(lastSpawn, 0, 0);

                // Add player as a child
                newPlayer.transform.parent = this.transform;

                // Subscribe to each player
                newPlayer.GetComponent<PlayerController>().Subscribe(this);
            }
        }

        public override int NormalizeScore(int score)
        {
            return score;
        }
    }
}
