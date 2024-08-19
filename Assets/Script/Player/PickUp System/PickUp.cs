using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform; //player camera
    [SerializeField] private float pickUpDistance = 5f;       //min distamce to pickup objects
    [SerializeField] private LayerMask pickUpLayerMask;       //layer mask for pickable abjects

    [SerializeField] private Transform objectGrabPointTransform;

    private ObjectGrabable objectGrabable;                    // reference to object grabbable script


    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(playerCameraTransform.transform.position, playerCameraTransform.forward * pickUpDistance, Color.red);    //visualize ray

        //checking for Input and Raycast to identify objects
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabable == null)    //not carrying any object
            {
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHist, pickUpDistance, pickUpLayerMask))
                {
                    Debug.Log("pickup ray" + raycastHist.transform);

                    if (raycastHist.transform.TryGetComponent(out objectGrabable))
                    {
                        Debug.Log(objectGrabable);

                        objectGrabable.Grab(objectGrabPointTransform);
                    }
                }
            }
            else
            {
                objectGrabable.Drop();
                objectGrabable = null;
            }
        }

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    if (objectGrabable != null)
        //    {
        //        objectGrabable.Drop();
        //        objectGrabable = null;
        //    }
        //}
    }
}