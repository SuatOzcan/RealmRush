using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    void Start()
    {
        PathFinder pathFinder = FindObjectOfType<PathFinder>();
        List<Waypoint> path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    

    //[SerializeField] List<Waypoint> path;

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting: " + waypoint);
            yield return new WaitForSecondsRealtime(1f);
        }
        print("Ending patrol.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
 