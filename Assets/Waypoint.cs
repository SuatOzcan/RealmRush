﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    const int gridSize = 10;
    Vector2Int gridPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetGridSize()
    {
        return  gridSize;
    }

    public Vector2Int GetGridPos()
    {
        return new Vector2Int(gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
        gridPos.y = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponentInChildren<MeshRenderer>();
        topMeshRenderer.material.color = color;
       
    }
}
