using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    static bool inputEnabled = true;
    public static bool InputEnabled {
        get { return inputEnabled; }
        set { inputEnabled = value; }
    }

	public static void ChangeScene(string scene) {
        SceneManager.LoadScene(scene);
    }
	
    public static void ExitGame() {
        Application.Quit();
    }
}
