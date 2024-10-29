using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public EntityTracker entityTracker;

    private void Update()
    {
        foreach (WorkerMain worker in entityTracker.workers)
        {
            if (worker.data.isGathering)
            {
                worker.functions.GatherResource();
            }
        }
    }
}
