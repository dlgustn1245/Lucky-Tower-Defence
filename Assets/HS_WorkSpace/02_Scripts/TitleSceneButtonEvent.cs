using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneButtonEvent : MonoBehaviour
{
    public void OnClickStartGame()
    {
        SceneManager.LoadScene("Stage");
    }

    public void OnClickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
