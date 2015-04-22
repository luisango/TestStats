using UnityEngine;
using System.Collections;


public class BackButton : MonoBehaviour 
{
    public void OnClickBackButton()
    {
        Manager.Scene.Instance.Load(Manager.Scene.Type.MainMenu);
	}
}
