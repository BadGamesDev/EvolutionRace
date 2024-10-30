using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingData : MonoBehaviour
{
    public List<ButtonAction> buttonActions = new();
    public void Start()
    {
        ButtonAction comolokko = new ButtonAction
        {
            actionName = "Move",
            actionMethod = Move
        };

        buttonActions.Add(comolokko);
    }

    private void Move()
    {
        Debug.Log("trying to comolokko");
    }
}
