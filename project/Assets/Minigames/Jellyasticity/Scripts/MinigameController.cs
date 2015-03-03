﻿using UnityEngine;
using System.Collections;


namespace Jellyasticity
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
