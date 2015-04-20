using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ArrowButtons : MonoBehaviour
{
    public Text text;

    private int num = 0;

    public void Update()
    {
        text.text = "" + num;
    }

    public void Add()
    {
        num++;
    }

    public void Sustract()
    {
        if (num >0) num--;
    }
}