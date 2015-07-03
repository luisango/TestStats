using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour
{
	public void OnClickStartGame()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.MainMenu);
    }
}
