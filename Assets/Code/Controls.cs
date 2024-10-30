using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameState gameState;
    public MainUIFunctions mainUIFunctions;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                HandleLeftClick(clickedObject);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.collider.gameObject;
                HandleRightClick(clickedObject);
            }
        }
    }

    void HandleLeftClick(GameObject clickedObject)
    {
        if (clickedObject.CompareTag("Worker"))
        {
            gameState.selectedWorkers.Add(clickedObject.GetComponent<WorkerMain>());
        }
        else if (clickedObject.CompareTag("Resource"))
        {
            Debug.Log("clicked resource");
        }
        else if (clickedObject.CompareTag("Building"))
        {
            gameState.selectedBuildings.Add(clickedObject.GetComponent<BuildingMain>());
            mainUIFunctions.UpdateButtonFunctions();
            Debug.Log("clicked building");
        }
    }

    void HandleRightClick(GameObject clickedObject)
    {
        if (clickedObject.CompareTag("Worker"))
        {
            gameState.selectedWorkers.Add(clickedObject.GetComponent<WorkerMain>());
        }
        else if (clickedObject.CompareTag("Resource"))
        {
            if(gameState.selectedWorkers != null)
            {
                foreach (WorkerMain worker in gameState.selectedWorkers)
                {
                    worker.data.resourceSite = clickedObject;
                    worker.data.carryType = clickedObject.GetComponent<ResourceData>().type; 
                }
            }
        }
        else if (clickedObject.CompareTag("Building"))
        {
            Debug.Log("clicked building");
        }
    }
}
