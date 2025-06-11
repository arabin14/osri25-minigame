using UnityEngine;

public class CameraController : MonoBehaviour
{
    // MOVES TO CENTER OF SECTION
    /*[SerializeField] private float cameraSpeed;
    private float currentPositionX;
    private Vector3 velocity = Vector3.zero;

    private void Update() 
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPositionX, transform.position.y, transform.position.z), ref velocity, cameraSpeed);
    }

    // Idea is that when player enters new room, camera moves to center of it
    public void MoveToNewSection(Transform _newSection)
    {
        currentPositionX = _newSection.position.x;
    } */

    // FOLLOWS THE PLAYER
    public GameObject player;

    // Update is called once per frame
    void Update() 
    {
        // only follows change on x axis
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
