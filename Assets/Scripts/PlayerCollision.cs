using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField] private PlayerMovement _movement;
    private GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Obstacle") {
            _movement.enabled = false;
            _gameManager.EndGame();
        }
        
    }
}
