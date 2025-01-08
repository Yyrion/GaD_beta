using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,1.5f,-3);

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, player.transform.position + offset, 0.1f);
    }
}
