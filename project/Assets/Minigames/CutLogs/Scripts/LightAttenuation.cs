using UnityEngine;
using System.Collections;


namespace Jellyasticity
{
    public class LightAttenuation : MonoBehaviour {

        public float duration = 5.0f;

        private Light l;

	    // Use this for initialization
	    void Start () {
            l = GetComponent<Light>();
	    }
	    
	    // Update is called once per frame
	    void Update () {
            float phi = Time.time / duration * 2 * Mathf.PI;
            float amplitude = Mathf.Cos(phi) * 0.5f;
            l.intensity = amplitude;
	    }
    }
}
