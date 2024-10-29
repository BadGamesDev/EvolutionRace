using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerFunctions : MonoBehaviour
{
    public WorkerData data;
    private Vector3 targetPosition;
    private bool shouldMove = false;

    public void MoveToPoint(Vector3 newTargetPosition)
    {
        targetPosition = newTargetPosition;
        shouldMove = true;
    }

    public void GatherResource()
    {
        data.gatherProgress += data.gatherSpeed;
        if (data.gatherProgress >= 100)
        {
            data.gatherProgress -= 100;
            data.carryAmount += 1;
            data.resourceSite.GetComponent<ResourceFunctions>().DecreaseAmount(1);
        }
    }

    public void DropResource()
    {
        data.faction.functions.IncreaseResource(data.carryType, data.carryAmount);
        data.carryAmount = 0;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, data.speed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                shouldMove = false;
            }
        }
    }
}
