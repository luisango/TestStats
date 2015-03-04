using UnityEngine;
using System.Collections;


namespace SweetRain
{
    public class MinigameController : Minigame.Controller
    {

        public GameObject m_dropContainer;
        public GameObject m_rainDropPrefab;
        public Vector2 m_rainDropSpawnRange;
        float timeCount = 0;
        private int m_numDrops = 5;

        // Aqui van los métodos que implementan la logica del minijuego. //
        public void Update()
        {
            if (timeCount > 90) {
                timeCount = 0;
                for (int drop = 0; drop < m_numDrops; drop++) {
                    InstantiateRainDrop();
                }
            }
            timeCount++;
        }

        public override bool OnEvent(int evt)
        {
            return base.OnEvent(evt);

            // Custom event handling...
        }

        protected void InstantiateRainDrop()
        {
            GameObject o = (GameObject)Instantiate(m_rainDropPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            o.transform.parent = m_dropContainer.transform;

            o.transform.position = new Vector3(Random.Range(m_rainDropSpawnRange.x, m_rainDropSpawnRange.y), 4, 0);
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
