using UnityEngine;


//This is the script for grabbable objects


public class ObjectGrabable : MonoBehaviour
{
    private Rigidbody objectRigidBody;                 // pickable object rigidbody
    private Transform objectGrabPointTransform;        // pickable object transforms

    private void Awake()
    {
        objectRigidBody = GetComponent<Rigidbody>();         //Assign rigidbody
    }



    public void Grab(Transform objectGrabPointTransform)              //Grab object
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidBody.useGravity = false;
    }


    private void FixedUpdate()
    {
        //if (objectGrabPointTransform != null)
        {
            if (objectGrabPointTransform != null)
            {
                float lerpSpeed = 10f;
                Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);

                objectRigidBody.MovePosition(newPosition);

            }
        }
    }

    public void Drop()
    {
        objectGrabPointTransform = null;
        objectRigidBody.useGravity = true;
    }
}