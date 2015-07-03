using UnityEngine;
using System.Collections;
using System.Collections.Generic;


namespace Manager
{
    /// <summary>
    /// Scene Manager.
    /// </summary>
    public class Scene : Utils.Singleton<Scene>
    {
        /// <summary>
        /// Common scenes listed as enum for internal use.
        /// </summary>
        public enum Type
        {
            MainMenu,
            SelectMinigame,
            SelectPlayers,
            ConfigPlayers,
            Credits,
            Board,
            Minigame,
            Results,
            Victory
        };


        /// <summary>
        /// Loads a scene
        /// </summary>
        /// <param name="scene">Scene (definition) to load</param>
        public void Load(Type scene)
        {
            if (scene == Type.Board)
                Manager.Board.Instance.PreRespawn();

            Load(scene.ToString());
        }

        /// <summary>
        /// Load a scene by name.
        /// </summary>
        /// <param name="name">Scene name to load</param>
        public void Load(string name)
        {
            Debug.Log("CHANGE SCENE TO: " + name);
            Application.LoadLevel(name);
        }
    }
}
