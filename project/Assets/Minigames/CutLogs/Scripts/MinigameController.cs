using UnityEngine;
using System.Collections;


namespace CutLogs
{
    public class MinigameController : Minigame.Controller
    {
        public enum CustomEvents
        {
            RockTime,
            BubbleTime
        };

        public override bool OnEvent(int evt)
        {
            bool baseEvt = base.OnEvent(evt);

            switch (evt)
            {
                case (int)CustomEvents.RockTime:
                    // ROCK TIME!
                    break;

                default:
                    break;
            }

            return true && baseEvt;
        }

        protected override void InstantiatePlayers()
        {
            // Hardcoded spawn metrics
            Vector2 spawnRange = new Vector2(-5, 3);//new Vector2(-11, 9);
            float spawnLength = spawnRange.y - spawnRange.x;
            //float spawnStep = spawnLength / (Manager.Player.Instance.Get().Count * 2);
            //float lastSpawn = spawnRange.x;
            float spawnStepX = spawnLength / (Manager.Player.Instance.Get().Count * 2);
            float spawnStepY = spawnLength / (Manager.Player.Instance.Get().Count * 2);

            float lastSpawnX = spawnRange.x;
            float lastSpawnY = 0;

            for (int i = 0; i < Manager.Player.Instance.Get().Count; i++)
            {
                // Instantiate player
                GameObject newPlayer = InstantiatePlayer();

                // Set position
                //lastSpawn += spawnStep;
                lastSpawnX += spawnStepX;
                newPlayer.transform.position = new Vector3(lastSpawnX, lastSpawnY, 0); //new Vector3(lastSpawn, 0, 0);
                lastSpawnY += spawnStepY;

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
