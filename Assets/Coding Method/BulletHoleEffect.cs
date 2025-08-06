using UnityEngine;

public class BulletHoleEffect : MonoBehaviour
{
    public GameObject holePrefab;  // Reference to the HoleCylinder prefab
    public float holeRadius = 0.2f;
    public float holeDepth = 0.2f;

    private GameObject currentHole;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                CreateHole(hit.point, -ray.direction, hit.normal);
            }
        }
    }

    void CreateHole(Vector3 position, Vector3 direction, Vector3 normal)
    {
        // If there's already a hole, remove it before creating a new one
        if (currentHole != null)
        {
            Destroy(currentHole);
        }

        // Instantiate a new hole cylinder at the hit position
        currentHole = Instantiate(holePrefab, position, Quaternion.LookRotation(direction));

        // Adjust scale and rotation of the hole to match the desired depth and radius
        currentHole.transform.localScale = new Vector3(holeRadius, holeDepth, holeRadius);
        currentHole.transform.Rotate(90, 0, 0);  // Align the cylinder along the bullet path
    }
}
