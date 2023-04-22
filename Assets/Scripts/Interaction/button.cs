using UnityEngine;

public class button : MonoBehaviour
{
    private Material originalMaterial;
    public Camera mainCamera;

    private void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
        mainCamera = Camera.main;
    }

    private void Update()
    {
         RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
           
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Material newMaterial = Resources.Load<Material>("Blue"); // Replace "MaterialName" with the name of the material you want to use
                    if (newMaterial != null) // Check if the material was loaded successfully
                    {
                        GetComponent<Renderer>().material = newMaterial;
                    }
                    else
                    {
                        Debug.LogError("Could not load material!");
                    }
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
    }
}
