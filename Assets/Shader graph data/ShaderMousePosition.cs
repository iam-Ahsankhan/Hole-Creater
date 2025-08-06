using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShaderMousePosition : MonoBehaviour
{
    public Material cutMaterial; // Material that has the shader
    public float intensity = 0.5f; // Hole size
    public float meshThickness = 0.5f; // Hole size

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // On left mouse click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Get the world position where the raycast hit the object
                Vector3 hitPosition = hit.point;

                // Pass the hit point and intensity to the shader
                cutMaterial.SetVector("_MousePosition", hitPosition);
                cutMaterial.SetFloat("_Intensity", intensity);
                cutMaterial.SetFloat("_Thickness", meshThickness);
            }
        }
    }
}
