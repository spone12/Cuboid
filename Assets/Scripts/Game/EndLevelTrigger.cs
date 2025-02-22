using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{

    public GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameManager.LevelComplete();
        }
    }
}
