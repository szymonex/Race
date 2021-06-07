using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadMenuOnly()
    {
        SceneManager.LoadScene(0); //lub nazwa sceny, nie ma LoadSceneMode.Additive więc wszystko zostanie zastąpione sceną nr 0 czyli Menu
    }

    public void LoadMap(string mapName)
    {
        SceneManager.LoadScene(mapName, LoadSceneMode.Additive); //LoadSceneMode żeby dodać ładowaną scenę a nie zastąpić obecną (menu)
    }
}
