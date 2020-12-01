using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(ARRaycastManager))]
public class ARManager : MonoBehaviour
{
    [Header("obj")]
    public GameObject obj;
    [Header("AR")]
    public ARRaycastManager arr;

    private Vector2 mouse;
    private List<ARRaycastHit> hit;

    private void tap()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mouse = Input.mousePosition;
            if(arr.Raycast(mouse, hit, TrackableType.PlaneWithinPolygon))
            {
                Instantiate(obj, hit[0].pose.position, Quaternion.identity);
            }
        }
    }

    private void Update()
    {
        tap();
    }
}
