using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
    public void OnClickStartButton()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.SelectPlayers);
    }

    public void OnClickCreditsButton()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.Credits);
    }

    public void OnClickExitButton()
    {
        Application.Quit();
    }
}
