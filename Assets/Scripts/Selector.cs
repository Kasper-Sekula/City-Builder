using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    private Camera cam;

    public static Selector instance;

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        cam = Camera.main;    
    }

    public Vector3 GetCurTilePosition()
    {
        // Checking if cursor is on UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return new Vector3(0, -99, 9);
        }

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float rayOut = 0.0f;

        if (plane.Raycast(ray, out rayOut))
        {
            Vector3 newPos = ray.GetPoint(rayOut) - new Vector3(0.5f, 0.0f, 0.5f);
            // Rounding up
            newPos = new Vector3(Mathf.CeilToInt(newPos.x), 0.0f, Mathf.CeilToInt(newPos.z));
            print(newPos);
            return newPos;
        }

        return new Vector3(0, -99, 0);
    }
}
