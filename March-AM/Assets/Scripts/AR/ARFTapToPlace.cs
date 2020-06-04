using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARFTapToPlace : MonoBehaviour
{
    public GameObject m_prefabObject;

    private Transform m_placedTransform;

    public static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    ARRaycastManager m_raycastManager;

    // Start is called before the first frame update
    void Start()
    {
        m_raycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {

            Vector2 touchPosition = Input.GetTouch(0).position;

            if(m_raycastManager.Raycast(touchPosition, s_hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_hits[0].pose;

                if(!m_placedTransform)
                {
                    m_placedTransform = Instantiate(m_prefabObject, hitPose.position, hitPose.rotation).transform;
                }
                else
                {
                    m_placedTransform.position = hitPose.position;
                }
            }
        }
    }
}
