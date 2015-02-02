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
            SelectMinigame,
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
            Load(scene.ToString());
        }

        public void Load(string name)
        {
            Debug.Log("CHANGE SCENE TO: " + name);
            Application.LoadLevel(name);
        }
    }
}
