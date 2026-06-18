using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    private const string CORE_SCENE = "CoreScene";

    
    [Header("Main Menu Settings")]
    [SerializeField] private string startingScene = "Scene Name";


    public void OnPlayPress()
    {
        SceneManager.LoadScene(startingScene);
        SceneManager.LoadScene(CORE_SCENE, LoadSceneMode.Additive);
    }


    public void OnSettingsPress()
    {

    }


    public void OnQuitPress() => Application.Quit();
}
