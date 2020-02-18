using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]

public class CubeEditor : MonoBehaviour {

    [SerializeField] Waypoint startWaypoint, endWayPoint;

    Waypoint Waypoint;

    private void Awake()
    { 
        Waypoint = GetComponent<Waypoint>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        SnapToGrid();

        UpdateLabel();
    }

    private void SnapToGrid()
    {
        int gridSize = Waypoint.GetGridSize();
        
        transform.position = new Vector3(
            Waypoint.GetGridPos().x * gridSize,
            0f,
            Waypoint.GetGridPos().y * gridSize);
    }

    private void UpdateLabel()
    {
        int gridSize = Waypoint.GetGridSize();
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string labelText = 
            Waypoint.GetGridPos().x + "," + Waypoint.GetGridPos().y ;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
