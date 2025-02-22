using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{

    public Transform player;
    [SerializeField] private Vector3 offset;

    void Update() {
        transform.position = player.position + offset;
    }
}
