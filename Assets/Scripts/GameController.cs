using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController Instance;

    public Transform spawnPoint;
    public GameObject playerPrefab;
    public GameObject deathNode;
    public AudioClip deathSound;
    public AudioSource sfxSource;
    public static bool lampOn;

    public static int deaths = -1;

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

    public static void Respawn() {
        
        if (PlayerControl.Instance != null) {
            deaths++;
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            Instance.TrimPath();
            PlaySFX(Instance.deathSound);
        }
        GameObject newPlayer = Instantiate(Instance.playerPrefab, Instance.spawnPoint.position, Quaternion.identity);
        newPlayer.name += deaths;
        
        
        GameController.lampOn = false;
    }
    void TrimPath() {
        GameObject player  = GameObject.FindGameObjectWithTag("Player");
        Tether path = player.GetComponentInChildren<Tether>();
        Instantiate(deathNode, path.link[path.link.Count-1].transform.position, Quaternion.identity);
    }
	public static void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }
	
    public static void ExitGame() {
        Application.Quit();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.F1))
            ChangeScene("Level_1");
    }

}
