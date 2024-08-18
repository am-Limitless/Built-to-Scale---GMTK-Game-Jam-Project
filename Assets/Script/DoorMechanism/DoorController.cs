using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform doorLeft;         // Reference to the left door panel
    public Transform doorRight;        // Reference to the right door panel
    public Transform door;             // Reference to the parent door object containing the children
    public float doorMoveDistance = 2f; // Distance each door will move when opening
    public float doorMoveSpeed = 5f;   // Speed at which the doors will move

    private float leftDoorClosedPosX;  // Initial X position for the left door
    private float rightDoorClosedPosX; // Initial X position for the right door
    private bool isOpen = false;
    public Transform key;

    void Start()
    {
        // Store the initial closed X positions of both doors
        leftDoorClosedPosX = doorLeft.position.x;
        rightDoorClosedPosX = doorRight.position.x;
    }

    void Update()
    {
        if (isOpen)
        {
            // Move the left door to its open position by decreasing the X value
            float targetLeftDoorPosX = leftDoorClosedPosX - doorMoveDistance;
            doorLeft.position = new Vector3(Mathf.Lerp(doorLeft.position.x, targetLeftDoorPosX, Time.deltaTime * doorMoveSpeed), doorLeft.position.y, doorLeft.position.z);

            // Move the right door to its open position by increasing the X value
            float targetRightDoorPosX = rightDoorClosedPosX + doorMoveDistance;
            doorRight.position = new Vector3(Mathf.Lerp(doorRight.position.x, targetRightDoorPosX, Time.deltaTime * doorMoveSpeed), doorRight.position.y, doorRight.position.z);
        }
    }

    public void OpenDoors()
    {
        isOpen = true;

        // Disable all BoxColliders on the child objects of the door
        foreach (BoxCollider boxCollider in door.GetComponentsInChildren<BoxCollider>())
        {
            boxCollider.enabled = false;
        }

        // Deactivate the key object to make it disappear
        if (key != null)
        {
            key.gameObject.SetActive(false);
        }
    }
}
