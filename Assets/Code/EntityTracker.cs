using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTracker : MonoBehaviour
{
    public List<GameObject> resources = new();
    public List<WorkerMain> workers = new();
    public List<GameObject> buildings = new();

    void Start()
    {
        UpdateEntityLists();
    }

    public void UpdateEntityLists()
    {
        resources = new List<GameObject>(GameObject.FindGameObjectsWithTag("Resource"));
        foreach (GameObject workerObject in GameObject.FindGameObjectsWithTag("Worker"))
        {
            WorkerMain worker = workerObject.GetComponent<WorkerMain>();
            if (worker != null)
            {
                workers.Add(worker);
            }
        }
        buildings = new List<GameObject>(GameObject.FindGameObjectsWithTag("Building"));
    }
}
