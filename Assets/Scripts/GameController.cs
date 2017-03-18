using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController Instance;

    public GameObject playerPrefab;
    public AudioSource sfxSource;

    public static int deaths = 0;

    static bool inputEnabled = true;
    public static bool InputEnabled {
        get { return inputEnabled; }
        set { inputEnabled = value; }
    }

    void Awake() {
        Instance = this;
    }

    public static void PlaySFX(AudioClip clip) {
        Instance.sfxSource.clip = clip;
        Instance.sfxSource.Play();
    }

    public static void Respawn(Vector3 spawnPoint) {
        deaths++;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        GameObject newPlayer = Instantiate(Instance.playerPrefab, spawnPoint, Quaternion.identity);
        newPlayer.name += deaths;
    }

	public static void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }
	
    public static void ExitGame() {
        Application.Quit();
    }
}
