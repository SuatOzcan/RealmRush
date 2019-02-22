using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] List<Waypoint> path;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(PrintAllWaypoints());
        print("Hey I'm back at Start");
    }

    IEnumerator PrintAllWaypoints()
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting: " + waypoint);
            yield return new WaitForSecondsRealtime(1f);
        }
        print("Ending patrol");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
