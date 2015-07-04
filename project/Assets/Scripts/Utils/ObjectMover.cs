using UnityEngine;
using System.Collections;

public class ObjectMover : MonoBehaviour
{

    private bool m_moving;
    private float m_totalTime;
    private float m_t;

    private Vector3 m_initial;
    private Vector3 m_end;

    private Quaternion m_initialDir;
    private Quaternion m_endDir;

    public GameObject m_1;
    public GameObject m_2;

    // Use this for initialization
    void Start()
    {
        m_moving = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (m_moving)
        {
            m_t += Time.deltaTime * m_totalTime;
            Mathf.Clamp(m_t, 0.0f, 1.0f);

            if (m_t >= 1.0f)
            {
                m_moving = false;
            }

            transform.rotation = Quaternion.Slerp(m_initialDir, m_endDir, m_t);
            transform.position = Vector3.Lerp(m_initial, m_end, m_t);


        }
    }

    void StartCameraMovement(Transform initObject, Transform endObject, float totalTime)
    {
        if (!m_moving)
        {
            m_initial = initObject.position;
            m_end = endObject.position;

            m_initialDir = initObject.rotation;
            m_endDir = endObject.rotation;

            m_totalTime = 1.0f / totalTime;
            m_t = 0.0f;
            m_moving = true; ;
        }

    }
}
