using UnityEngine;

public class ShrinkRoom : MonoBehaviour
{
    public Transform leftWall; // left side wall
    public Transform rightWall; // right side wall
    public float shrinkSpeed = 2f; // speed of wall movement
    public float minDistance = 1f; // min distance of wall


    void Update()
    {
        float currentDistance = Vector3.Distance(leftWall.position, rightWall.position);

        if (currentDistance > minDistance)
        {
            leftWall.position += Vector3.right * shrinkSpeed * Time.deltaTime;

            rightWall.position += Vector3.left * shrinkSpeed * Time.deltaTime;
        }
    }
}
