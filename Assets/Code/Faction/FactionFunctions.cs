using UnityEngine;

public class FactionFunctions : MonoBehaviour
{
    public MainUIFunctions mainUIFunctions;
    public FactionData data;

    public void IncreaseResource(int type, int amount)
    {
        if (type == 1)
        {
            data.food += amount;
        }
                
        else if (type == 2)
        {
            data.wood += amount;
        }

        else if (type == 3)
        {
            data.stone += amount;
        }

        mainUIFunctions.UpdateUI();
    }

    public void DecreaseResource(int type, int amount)
    {
        if (type == 1)
        {
            data.food += amount;
        }

        else if (type == 2)
        {
            data.wood += amount;
        }

        else if (type == 3)
        {
            data.stone += amount;
        }

        mainUIFunctions.UpdateUI();
    }
}
