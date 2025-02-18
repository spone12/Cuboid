using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool _gameHasEnded = false;
    [SerializeField] private float _restartDelay = 1f;

    public GameObject completeLevelUI;

    public void LevelComplete() {
        completeLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (_gameHasEnded == false) {
            _gameHasEnded = true;
            Debug.Log("over");
            Invoke("Restart", _restartDelay);
        }
    }

    private void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
