using UnityEngine;
using System.Collections;


namespace SweetRain
{
    public class MinigameController : Minigame.Controller
    {
        // Rain objects:
        public GameObject m_dropContainer;
        public GameObject m_rainDropPrefab;    // bonus points
        public GameObject m_rainBadDropPrefab; // penalty points

        public Vector2 m_rainDropSpawnRange;
        float timeCount = 0;
        private int m_numDrops, m_maxDrops = 3;
        private int m_numBadDrops, m_maxBadDrops = 2;

        // Aqui van los métodos que implementan la logica del minijuego. //
        public override void OnUpdate()
        {
            // Generation sweet rain drops...(bonus rain)
            if (timeCount > Random.Range(30, 70))
            {
                m_numDrops = Random.Range(1, m_maxDrops);
                timeCount = 0;
                for (int drop = 0; drop < m_numDrops; drop++) {
                    InstantiateRainDrop();
                }
            }

            // Generation acid rain drops...(penalty rain)
            if (timeCount > Random.Range(30, 70))
            {
                m_numBadDrops = Random.Range(1, m_maxBadDrops);
                timeCount = 0;
                for (int drop = 0; drop < m_numBadDrops; drop++)
                {
                    InstantiateRainBadDrop();
                }
            }

            timeCount++;
        }

        // << Instantiation Rain drops >>
        // Using two types of diferents instantiation because the logic game
        // to RainDrop and to RainBadDrop is different.
        protected void InstantiateRainDrop()
        {
            GameObject o = (GameObject)Instantiate(m_rainDropPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            o.transform.parent = m_dropContainer.transform;

            o.transform.position = new Vector3(Random.Range(m_rainDropSpawnRange.x, m_rainDropSpawnRange.y), 5, 0);
        }

        protected void InstantiateRainBadDrop()
        {
            GameObject o = (GameObject)Instantiate(m_rainBadDropPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            o.transform.parent = m_dropContainer.transform;

            o.transform.position = new Vector3(Random.Range(m_rainDropSpawnRange.x, m_rainDropSpawnRange.y), 5, 0);
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
