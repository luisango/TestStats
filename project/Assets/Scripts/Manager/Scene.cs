using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Manager
{
    /// <summary>
    /// Scene Manager
    /// </summary>
    public class Scene : Utils.Singleton<Scene>
    {
        public enum Type
        {
            MainMenu,
            SelectPlayers,
            ConfigPlayers,
            Credits,
            Board,
            Minigame
        };

        public Scene()
        {
        }

        /// <summary>
        /// Loads a scene
        /// </summary>
        /// <param name="scene">Scene (definition) to load</param>
        public void Load(Type scene)
        {
            Debug.Log("CHANGE SCENE TO: " + scene.ToString());
            Application.LoadLevel(scene.ToString());
        }
    }
}
