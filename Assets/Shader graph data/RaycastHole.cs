using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaycastHole : MonoBehaviour
{
    public Material holeMaterial;   // Reference to the material with the hole shader
    public Camera mainCamera;       // Reference to the main camera
    public float holeIntensity = 1.0f;  // Size/Intensity of the hole

    void Update()
    {
        // Detect mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Convert hit point to local space of the hit object
                Vector3 localHitPoint = hit.transform.InverseTransformPoint(hit.point);

                // Update the shader with the hole position and size
                holeMaterial.SetVector("_HolePosition", new Vector4(localHitPoint.x, localHitPoint.y, localHitPoint.z, 0));
                holeMaterial.SetFloat("_HoleSize", holeIntensity);
            }
        }
    }
}