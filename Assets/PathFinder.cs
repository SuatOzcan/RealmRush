using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour {

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    [SerializeField] Waypoint startWaypoint, endWayPoint;
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
	// Use this for initialization
	void Start () {

        LoadBlocks();
        ColorStartAndEnd();
        //ExploreNeighbours(startWaypoint);
        PathFind();
    }

    private void PathFind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count>0 && isRunning)
        {
            
            var searchCenter = queue.Dequeue();
            print(searchCenter);
            HaltIfEndFound(searchCenter);
            ExploreNeighbours(searchCenter);
        }
        print("Finish pathfinding.");
    }

    private void HaltIfEndFound(Waypoint searchCenter)
    {
        if (searchCenter==endWayPoint)
        {
            print("searching from end node, therefore stopping.");
            isRunning = false;
        }
    }

    private void ExploreNeighbours(Waypoint from )
    {
        if (!isRunning) return;

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = from.GetGridPos() + direction;
            print("Exploring " + neighbourCoordinates);
            try
            {
                Waypoint neighbour = grid[neighbourCoordinates];
                neighbour.SetTopColor(Color.blue);
                queue.Enqueue(neighbour);
                print("Queueing" + neighbour.name);
            }
            catch (Exception)
            {

                //do nothing.
            }
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

        print("Loaded " +grid.Count + "blocks");

    }

    // Update is called once per frame
    void Update () {
		
	}
}
