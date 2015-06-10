using UnityEngine;
using System.Collections;


namespace SweetRain
{
    public class MinigameController : Minigame.Controller
    {
        // Rain objects:
        public GameObject m_dropContainer;

        public GameObject[] m_drops_objects;

        public Vector2 m_rainDropSpawnRange;
        float timeCount = 0;

        private int m_minDrops = 1;
        private int m_maxDrops = 4;

        // Aqui van los métodos que implementan la logica del minijuego. //
        public override void OnUpdate()
        {
            // Generation of differents rain drops...
            if (timeCount > Random.Range(30, 70))
            {
                int id = Random.Range(0, m_drops_objects.Length);
                int m_numDrops = 0;

                if (id == 1)// bad rain drop (penalty points)
                    m_numDrops = Random.Range(1, 2);
                else        // sweet rain drop (bonus points)
                    m_numDrops = Random.Range(m_minDrops, m_maxDrops);

                timeCount = 0;
                for (int drop = 0; drop < m_numDrops; drop++) {
                    InstantiateRainDrop(id);
                }
            }
            timeCount++;
        }

        // << Instantiation Rain drops >>
        // It can instantiate any good or bad drop (bonus or penalty points)
        protected void InstantiateRainDrop(int id)
        {
            GameObject o = (GameObject)Instantiate(m_drops_objects[id], new Vector3(0, 0, 0), Quaternion.identity);
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
