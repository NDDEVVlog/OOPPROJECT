using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection _connection;

    [SerializeField]
    private string _targetScenceName;

    [SerializeField]
    private Transform _spawnPoint;

    private void Start()
    {
        if (_connection == LevelConnection.ActiveConnection)
        {
            FindObjectOfType<Controller>().transform.position = _spawnPoint.position;
        }
    }
    private string _targetSceneName;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<Controller>();
        if (player != null)
        {
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }
    }
}
