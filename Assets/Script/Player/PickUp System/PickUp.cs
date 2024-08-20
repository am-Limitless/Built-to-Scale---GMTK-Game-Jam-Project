using UnityEngine;
using TMPro;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform; // Player camera
    [SerializeField] private float pickUpDistance = 5f;       // Min distance to pick up objects
    [SerializeField] private LayerMask pickUpLayerMask;       // Layer mask for pickable objects
    [SerializeField] private Transform objectGrabPointTransform; // Grab point for picked objects
    [SerializeField] private TextMeshProUGUI pickUpTextUI;    // Reference to the TextMeshPro UI element

    private ObjectGrabable currentObjectGrabable;             // Reference to the currently grabbed object

    void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * pickUpDistance, Color.red); // Visualize ray

        // Check if holding an object
        if (currentObjectGrabable != null)
        {
            // Drop the object if already holding one and E is pressed
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentObjectGrabable.Drop();
                currentObjectGrabable = null;
                pickUpTextUI.enabled = false; // Hide the text when the object is dropped
            }
            return;
        }

        // Checking for Raycast to identify objects
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
        {
            // If we hit an object that can be grabbed, display the pickup UI text
            if (raycastHit.transform.TryGetComponent(out ObjectGrabable objectGrabable))
            {
                pickUpTextUI.enabled = true; // Show the text

                // Check for input to pick up the object
                if (Input.GetKeyDown(KeyCode.E))
                {
                    objectGrabable.Grab(objectGrabPointTransform);
                    currentObjectGrabable = objectGrabable; // Store reference to the grabbed object
                    pickUpTextUI.enabled = false; // Hide the text after the object is picked up
                }
            }
            else
            {
                pickUpTextUI.enabled = false; // Hide the text if no valid object is found
            }
        }
        else
        {
            pickUpTextUI.enabled = false; // Hide the text if no object is in range
        }
    }
}
