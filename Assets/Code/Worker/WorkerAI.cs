using UnityEngine;

public class WorkerAI : MonoBehaviour
{
    public WorkerData data;
    public WorkerFunctions functions;

    private EntityTracker entityTracker;

    void Start()
    {
        entityTracker = FindAnyObjectByType<EntityTracker>();
    }

    void Update()
    {
        GatheringBehavior();
    }

    public void GatheringBehavior()
    {
        if (data.resourceSite == null)
        {
            FindResourceSite();
        }

        if (data.resourceSite != null && data.carryCapacity > data.carryAmount && transform.position != data.resourceSite.transform.position)
        {
            MoveToResourceSite();
        }

        if (data.resourceSite != null && data.carryCapacity > data.carryAmount && transform.position == data.resourceSite.transform.position)
        {
            GatherResource();
        }

        if (data.carryCapacity <= data.carryAmount)
        {
            data.isGathering = false;
        }

        if (data.dropSite == null && data.carryCapacity <= data.carryAmount)
        {
            FindDropSite();
        }

        if (data.dropSite != null && data.carryCapacity <= data.carryAmount)
        {
            MoveToDropSite();
        }

        if (data.dropSite != null && data.carryCapacity <= data.carryAmount && transform.position == data.dropSite.transform.position)
        {
            DropResource();
        }
    }

    void FindResourceSite()
    {
        if (entityTracker.resources.Count > 0 && data.carryType != 0)
        {
            float closestDistance = Mathf.Infinity;
            GameObject closestResource = null;

            foreach (GameObject resource in entityTracker.resources)
            {
                float distanceToResource = Vector2.Distance(transform.position, resource.transform.position);

                if (distanceToResource < closestDistance && data.carryType == resource.GetComponent<ResourceData>().type)
                {
                    closestDistance = distanceToResource;
                    closestResource = resource;
                }
            }

            if (closestResource != null)
            {
                data.resourceSite = closestResource;
            }
        }
    }

    void MoveToResourceSite()
    {
        functions.MoveToPoint(data.resourceSite.transform.position);
    }

    void GatherResource()
    {   
        if(data.carryCapacity > data.carryAmount)
        {
            data.isGathering = true;
        }
    }

    void FindDropSite()
    {
        if (entityTracker.buildings.Count > 0)
        {
            float closestDistance = Mathf.Infinity;
            GameObject closestDropSite = null;

            foreach (GameObject building in entityTracker.buildings)
            {
                float distanceToResource = Vector2.Distance(transform.position, building.transform.position);

                if (distanceToResource < closestDistance)
                {
                    closestDistance = distanceToResource;
                    closestDropSite = building;
                }
            }

            if (closestDropSite != null)
            {
                data.dropSite = closestDropSite;
            }
        }
    }

    void MoveToDropSite()
    {
        functions.MoveToPoint(data.dropSite.transform.position);
        Debug.Log("wanting to mue ");
    }

    void DropResource()
    {
        functions.DropResource();
    }
}
