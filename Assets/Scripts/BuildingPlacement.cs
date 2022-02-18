using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    private bool currentlyPlacing;
    private bool currentlyBulldozering;

    private BuildingPreset curBuildingPreset;

    private float indicatorUpdateRate = 0.05f;
    private float lastUpdateTime;
    private Vector3 curIndicatorPos;

    [SerializeField] GameObject placementIndicator;
    [SerializeField] GameObject bulldozeIndicator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }    

        if (Time.time - lastUpdateTime > indicatorUpdateRate)
        {
            lastUpdateTime = Time.time;
            curIndicatorPos = Selector.instance.GetCurTilePosition();

            if (currentlyPlacing)
            {
                placementIndicator.transform.position = curIndicatorPos;
            }
            else if (currentlyBulldozering)
            {
                bulldozeIndicator.transform.position = curIndicatorPos;
            }
        }

        if (Input.GetMouseButtonDown(0) && currentlyPlacing)
        {
            PlaceBuilding();
        }
        else if (Input.GetMouseButtonDown(0) && currentlyBulldozering)
        {
            Buldoze();
        }
    }

    public void BeginNewBuildingPlacement(BuildingPreset preset)
    {
        // Check money

        currentlyPlacing = true;
        curBuildingPreset = preset;
        placementIndicator.SetActive(true);
        placementIndicator.transform.position = new Vector3(0, -99, 0);
    }

    void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    public void ToggleBulldoze()
    {
        currentlyBulldozering = !currentlyBulldozering;
        bulldozeIndicator.SetActive(currentlyBulldozering);
        bulldozeIndicator.transform.position = new Vector3(0, -99, 0);
    }

    void PlaceBuilding()
    {
        GameObject buildObj = Instantiate(curBuildingPreset.GetPrefab(), curIndicatorPos, Quaternion.identity);
        // tell city script

        CancelBuildingPlacement();
    }

    void Buldoze()
    {

    }
}
