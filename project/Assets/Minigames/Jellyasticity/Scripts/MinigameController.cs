using UnityEngine;
using System.Collections;


namespace Jellyasticity
{
    public class MinigameController : Minigame.Controller
    {
        public GameObject m_objectContainer;
        public GameObject m_objectPrefab0;
        public GameObject m_objectPrefab1;
        public GameObject m_objectPrefab2;
        public GameObject m_objectPrefab3;
        public GameObject m_objectPrefab4;
        public GameObject m_objectPrefab5;
        public GameObject m_objectPrefab6;
        public Vector2 m_ObjectSpawnRange;
        float timeCount = 0;
        private int m_numObjects, m_maxObjects = 10;

        public override void OnUpdate()
        {
            if (timeCount > 500)
            {
                m_numObjects = Random.Range(5, m_maxObjects);
                timeCount = 0;
                for (int drop = 0; drop < m_numObjects; drop++)
                {
                    InstantiateObjects();
                }
            }
            timeCount++;
        }

        public void InstantiateObjects()
        {
            GameObject o = (GameObject)Instantiate(m_objectPrefab0, new Vector3(0, 0, 0), Quaternion.identity);
            o.transform.parent = m_objectContainer.transform;

            o.transform.position = new Vector3(Random.Range(m_ObjectSpawnRange.x, m_ObjectSpawnRange.y), Random.Range(2, 4), 0);
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
