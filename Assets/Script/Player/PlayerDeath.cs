using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // This script is for player death

    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject player;
    public GameObject playerDeathPannel;
    public float interval = 3f;

    private Collider playerCollider;
    private Collider leftCollider;
    private Collider rightCollider;

    void Start()
    {
        // Get the colliders of the walls & player
        playerCollider = player.GetComponent<Collider>();
        leftCollider = leftWall.GetComponent<Collider>();
        rightCollider = rightWall.GetComponent<Collider>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check is the player is pressed
        if (IsPlayerPressed())
        {
            KillPlayer();
        }
    }

    bool IsPlayerPressed()
    {
        bool isLeftWallTouching = playerCollider.bounds.Intersects(leftCollider.bounds);
        bool isRightWallTouching = playerCollider.bounds.Intersects(rightCollider.bounds);

        return isLeftWallTouching && isRightWallTouching;
    }

    void KillPlayer()
    {
        Debug.Log("Player is dead");
        playerDeathPannel.SetActive(true);
        StartCoroutine(SceneLoader());
        Destroy(player);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    IEnumerator SceneLoader()
    {
        yield return new WaitForSeconds(interval);
        SceneManager.LoadScene("Menu");
    }
}
