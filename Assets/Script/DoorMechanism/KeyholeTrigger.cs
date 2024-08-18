using UnityEngine;

public class KeyholeTrigger : MonoBehaviour
{
    public Transform key;
    public Transform snapPosition; // The position where the key should snap
    public float detectionRange = 2f; // Range of the raycast detection
    public LayerMask keyLayer; // LayerMask for the key
    public DoorController doorController; // Reference to the DoorController script

    private bool keySnapped = false;

    void Update()
    {
        if (!keySnapped)
        {
            // Draw the ray in the Scene view for debugging
            Debug.DrawRay(transform.position, -transform.up * detectionRange, Color.red);

            RaycastHit hit;
            // Cast the ray in the direction of the keyhole's forward direction
            if (Physics.Raycast(transform.position, -transform.up, out hit, detectionRange, keyLayer))
            {
                if (hit.collider.CompareTag("Key"))
                {
                    Debug.Log("Key detected by raycast");

                    // Snap the key to the keyhole
                    SnapKeyToKeyhole(hit.collider.transform);
                }
            }
            else
            {
                Debug.Log("Raycast did not hit anything");
            }
        }
    }

    void SnapKeyToKeyhole(Transform keyTransform)
    {
        Rigidbody keyRb = keyTransform.GetComponent<Rigidbody>();
        if (keyRb != null)
        {
            keyRb.velocity = Vector3.zero;
            keyRb.angularVelocity = Vector3.zero;
            keyRb.isKinematic = true; // Make it kinematic to stop physics interaction
        }

        keyTransform.position = snapPosition.position;

        Debug.Log("Key snapped to keyhole");

        keySnapped = true;

        OpenDoor();
    }

    void OpenDoor()
    {
        Debug.Log("Opening door...");
        // Call the OpenDoors method from the DoorController script
        if (doorController != null)
        {
            doorController.OpenDoors();
        }
        else
        {
            Debug.LogWarning("DoorController reference is missing!");
        }
    }
}
