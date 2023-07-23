using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private GameObject[] players;


    public int playerIndex;


    public GameObject getPlayer()
    {
        return this.players[this.playerIndex];
    }

    private void Awake()
    {
        if (GameManager.instance == null)
        {
            GameManager.instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this.gameObject);

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += this.OnSceneLoaded;
    }


    private void OnDisable()
    {
        SceneManager.sceneLoaded -= this.OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
        {
            Instantiate(this.players[playerIndex]);
        }
    }
}
