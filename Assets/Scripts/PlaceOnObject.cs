using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceOnObject : MonoBehaviour {

    [SerializeField]
    [Tooltip("Instantiate this prefab on a place at the touch location")]
    GameObject m_PlacedPrefab;

    UnityEvent placementUpdate;

    [SerializeField]
    GameObject visualObject;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;

    public GameObject placedPrefab
    {
        get { return m_PlacedPrefab; }
        set { m_PlacedPrefab = value; }
    }

    public GameObject spawnedObject { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();

        if (placementUpdate == null)
            placementUpdate = new UnityEvent();

            placementUpdate.AddListener(DiableVisual);
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // Raycast hits are sorted by distance, so the first one
            // will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(m_PlacedPrefab, hitPose.position, hitPose.rotation);

            }
            else
            {
                //repositioning of the object 
                spawnedObject.transform.position = hitPose.position;
            }
            placementUpdate.Invoke();
        }
    }

    private void DiableVisual()
    {
        visualObject.SetActive(false);
    }
}
