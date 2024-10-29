using UnityEngine;

public class MainUIFunctions : MonoBehaviour
{
    public MainUIData mainUIData;
    public FactionData playerFaction;

    public void UpdateUI()
    {
        mainUIData.FoodIndicator.text = playerFaction.food.ToString();
        mainUIData.WoodIndicator.text = playerFaction.wood.ToString();
        mainUIData.WoodIndicator.text = playerFaction.stone.ToString();
    }
}
