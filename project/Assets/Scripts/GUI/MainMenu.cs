using UnityEngine;
using System.Collections;


public class MainMenu : MonoBehaviour 
{
    /// <summary>
    /// Callback called when Start button is clicked.
    /// </summary>
    public void OnClickStartButton()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.SelectPlayers);
    }

    /// <summary>
    /// Callback called when Credits button is clicked.
    /// </summary>
    public void OnClickCreditsButton()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.Credits);
    }

    /// <summary>
    /// Callback called when Exit button is clicked.
    /// </summary>
    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
