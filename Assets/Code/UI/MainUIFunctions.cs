using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIFunctions : MonoBehaviour
{
    public GameState gameState;
    public MainUIData data;
    public FactionData playerFaction;

    public void UpdateUI()
    {
        data.FoodIndicator.text = "Food: " + playerFaction.food.ToString();
        data.WoodIndicator.text = "Wood: " + playerFaction.wood.ToString();
        data.WoodIndicator.text = "Stone: " + playerFaction.stone.ToString();
    }

    public void UpdateButtonFunctions()
    {
        if (gameState.selectedBuildings[0].data.buttonActions[0] != null)
        {
            data.button0.onClick.AddListener(gameState.selectedBuildings[0].data.buttonActions[0].actionMethod);
        }
    }
}
