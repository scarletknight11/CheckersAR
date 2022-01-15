using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;


public class PlaceObjectOnPlane : MonoBehaviour {

    private ARPlaneManager planeManager;
    private ARRaycastManager raycastManager;

    private List<ARRaycastManager> s_Hits = new List<ARRaycastManager>();

    public GameObject placedPrefab;

    public void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlacedObject()  
    {
        Touch touch = Input.GetTouch(0);

        //if(raycastManager.Raycast(touch.position, s_Hits, TrackableType.PlaneWithinPolygon)) {
        //    Pose hitPose = s_Hits[0].pose;
        //    Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        //}
    }
}
