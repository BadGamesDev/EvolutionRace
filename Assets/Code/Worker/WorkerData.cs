using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerData : MonoBehaviour
{
    public FactionMain faction;

    public int speed;
    public int carryCapacity;
    public int carryType;
    public int carryAmount;
    public int gatherSpeed;
    public int gatherProgress;

    public GameObject resourceSite;
    public GameObject dropSite;
    public bool isGathering;
}
