using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour {
   
    TextMesh textMesh;
    Vector3 gridPos;
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
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(gridPos.x, 0f, gridPos.z);
    }

    private void UpdateLabel()
    {
        int gridSize = Waypoint.GetGridSize();
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = gridPos.x / gridSize + "," + gridPos.z / gridSize;
        textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
