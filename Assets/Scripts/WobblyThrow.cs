using UnityEngine;

public class WobblyThrow : MonoBehaviour
{
    [SerializeField] private GameObject crosshairUI;
    [SerializeField] private GameObject aimCamera;
    [SerializeField] private MonoBehaviour movementScript;
    [SerializeField] private Rigidbody playerRigidbody;

    [SerializeField] private GameObject rock;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float throwForce = 15f;
    [SerializeField] private float rockLifetime = 5f;

    private bool isAiming = false;

    void Start()
    {
        if (crosshairUI != null) crosshairUI.SetActive(false);
        if (aimCamera != null) aimCamera.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) SetAiming(true);
        else if (Input.GetMouseButtonUp(1))
        {
            ThrowRock();
            SetAiming(false);
        }
    }

    void SetAiming(bool state)
    {
        isAiming = state;

        if (crosshairUI != null) crosshairUI.SetActive(state);
        if (aimCamera != null) aimCamera.SetActive(state);
        if (movementScript != null) movementScript.enabled = !state;
        if (playerRigidbody != null) playerRigidbody.isKinematic = state;
    }


    void ThrowRock()
    {
        if (rock == null || spawnPoint == null) return;

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out hit)) targetPoint = hit.point;
        else targetPoint = ray.GetPoint(75);

        GameObject currentRock = Instantiate(rock, spawnPoint.position, Quaternion.identity);
        Vector3 throwDirection = (targetPoint - spawnPoint.position).normalized;

        Rigidbody rb = currentRock.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        Destroy(currentRock, rockLifetime);
    }

}