﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWayPoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;
    Waypoint searchCenter;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

    public List<Waypoint> GetPath()
    {
        LoadBlocks();
        ColorStartAndEnd();
        BreadthFirstSearch();
        CreatePath();
        return path;

    }
	// Use this for initialization
	void Start () {

        
    }

    private void CreatePath()
    {
        path.Add(endWayPoint);
        Waypoint previous = endWayPoint.exploredFrom;
        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        }
        path.Add(startWaypoint);
        path.Reverse();
       /* foreach (Waypoint block in path)
        {
            print(block);
        } */
    }

    private void BreadthFirstSearch()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count>0 && isRunning)
        {
            
            searchCenter = queue.Dequeue();
            //print(searchCenter);
            HaltIfEndFound();
            ExploreNeighbours();
            searchCenter.isExplored = true;
        }
    }

    private void HaltIfEndFound()
    {
        if (searchCenter==endWayPoint)
        {
            //print("searching from end node, therefore stopping.");
            isRunning = false;
        }
    }

    private void ExploreNeighbours()
    {
        if (!isRunning) return;

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = searchCenter.GetGridPos() + direction;
            //print("Exploring " + neighbourCoordinates);
            try
            {
                QueueNewNeighbours(neighbourCoordinates);
            }
            catch (Exception)
            {

                //do nothing.
            }
        }
    }

    private void QueueNewNeighbours(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {
            //do nothing
        }
        else
        {
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            //print("Queueing" + neighbour.name);
        }
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWayPoint.SetTopColor(Color.green);
    }


    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();

        foreach (Waypoint waypoint in waypoints)
        {
            Vector2Int gridPos = waypoint.GetGridPos();
            bool isOverlapping = grid.ContainsKey(gridPos);
            if (isOverlapping)
            {
                print("Skipping Overlapping block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
        }

        //print("Loaded " +grid.Count + "blocks");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
