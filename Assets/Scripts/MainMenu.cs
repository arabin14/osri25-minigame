using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SelectArtwork");
    }

    public void StillLifeRun()
    {
        SceneManager.LoadSceneAsync("StillLifeRun");
    }

    public void SelfPortraitRun()
    {
        SceneManager.LoadSceneAsync("SelfPortraitRun");
    }

    public void ScholarsRockRun()
    {
        SceneManager.LoadSceneAsync("ScholarsRockRun");
    }

    public void GiantPlugRun()
    {
        SceneManager.LoadSceneAsync("GiantPlugRun");
    }

    public void FlyWhiskRun()
    {
        SceneManager.LoadSceneAsync("FlyWhiskRun");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
