using UnityEngine;

public class ResourceFunctions : MonoBehaviour
{
    private EntityTracker entityTracker;
    public ResourceData data;

    private void Awake()
    {
        entityTracker = FindFirstObjectByType<EntityTracker>();
    }

    public void DecreaseAmount(int amount)
    {
        data.amount -= amount;
        if (data.amount <= 0)
        {
            GetDepleted();
        }
    }

    public void IncreaseAmount(int amount)
    {
        data.amount += amount;
    }

    public void GetDepleted()
    {
        Debug.Log("depleted");
        entityTracker.resources.Remove(gameObject);
        Destroy(gameObject);
    }
}
