using UnityEngine;
using UnityEngine.EventSystems;

public class button : MonoBehaviour
{
public Material originalMaterial;
    public Camera mainCamera;
    public float rayLength;
    public LayerMask layerMask;     

    private void Start()
    {
        originalMaterial = GameObject.Find("Cube").GetComponent<Renderer>().material;
        mainCamera = Camera.main;
    }

    private void Update()
    {
   
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())  
        {
                 RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, rayLength, layerMask))
            {
Debug.Log(hit.collider.name);
                // (hit.collider.gameObject == gameObject)
                // {
                    
                //     Material newMaterial = Resources.Load<Material>("Blue"); // Replace "MaterialName" with the name of the material you want to use
                //     if (newMaterial != null) // Check if the material was loaded successfully
                //     {
                //         GetComponent<Renderer>().material = newMaterial;
                //     }
                //     else
                //     {
                //         Debug.LogError("Could not load material!");
                //     }
                // }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
