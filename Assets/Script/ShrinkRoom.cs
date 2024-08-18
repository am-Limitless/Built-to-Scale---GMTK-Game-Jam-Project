using UnityEngine;

public class ShrinkRoom : MonoBehaviour
{
    public Transform leftWall;
    public Transform rightWall;
    public float shrinkSpeed = 2f;
    public float minDistance = 1f;


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
