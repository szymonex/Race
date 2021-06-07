using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelConfig : MonoBehaviour
{
    

    [SerializeField] TextMeshProUGUI lapsText;
    [SerializeField] LapsSystem lapsSystem;
    [SerializeField] Slider sliderLaps;
    [SerializeField] GameObject restartPanel;

    int playerCarNumber = 0;
    [SerializeField] GameObject[] playerCars;
    [SerializeField] GameObject[] AICars;
    //[SerializeField] Transform[] startPoints;

    [SerializeField] Map[] maps;
    [SerializeField] TextMeshProUGUI mapName;
    [SerializeField] Image imageMap;

    public MapContainer mapContainer;

    int currentMapIdx = 0;

    void Start()
    {
        Time.timeScale = 0f;

        lapsSystem = (LapsSystem)GameObject.FindObjectOfType(typeof(LapsSystem)); //będzie znaleziony pierwszy obiekt tego typu, zakładamy więc najlepiej, że mamy tylko jeden obiekt tego typu
        if (lapsSystem == null)
        {
            Debug.LogError("LapsSystem is null in script PanelConfig!!!");
        }
        mapName.text = maps[0].mapName;
    }

    public void NextMap()
    {
        if (currentMapIdx < maps.Length - 1)
        {
            currentMapIdx++;
        }
        mapName.text = maps[currentMapIdx].mapName;
        imageMap.sprite = maps[currentMapIdx].thumbnail;
    }

    public void PreviousMap()
    {
        if (currentMapIdx > 0)
        {
            currentMapIdx--;
        }
        mapName.text = maps[currentMapIdx].mapName;
        imageMap.sprite = maps[currentMapIdx].thumbnail;
    }

    public void UpdateText(float value)
    {
        lapsText.text = value.ToString();
    }
    
    public void StartRaceCorutine()
    {
        StartCoroutine(StartRace());
    }

    public void RestartRaceCorutine()
    {
        restartPanel.SetActive(false);
        SceneManager.UnloadSceneAsync(maps[currentMapIdx].mapFileName);
        gameObject.SetActive(true);
        StartCoroutine(StartRace());
    }

    public IEnumerator StartRace() //połączone ze StartRaceCorutine()
    {
        Scene levelScene = SceneManager.LoadScene(maps[currentMapIdx].mapFileName, new LoadSceneParameters(LoadSceneMode.Additive)); //LoadSceneParameters żeby sprawdzić czy scena się już całkowicie załadowała i żeby zapisać w zmiennej Scene, LoadSceneMode żeby nie wywaliło sceny Menu tylko dodało ładowaną scenę do hierarchii

        yield return new WaitUntil(() => levelScene.isLoaded); //stosujemy tu konstrukcję predykatów
        mapContainer = FindObjectOfType<MapContainer>();
        if(mapContainer == null)
        {
            Debug.LogError("NIe znaleziono MapContainer w załadowanej scenie!");
        }


        //if (mapContainer == null)
        //{
        //    yield return null; //odczekanie jednej klatki
        //}

        lapsSystem.ConfigureRace(Mathf.RoundToInt(sliderLaps.value), mapContainer.checkpoints); //zaokrąglamy float do int
        Time.timeScale = 1f;
        SetUpPlayerCar(levelScene);
        SetUpAiCars(levelScene);
        gameObject.SetActive(false);
    }

    public void SetPlayerCarNumber(int carNumber)
    {
        playerCarNumber = Mathf.Clamp(carNumber, 0, playerCars.Length - 1);
    }

    public void SetUpPlayerCar(Scene scene)
    {
       GameObject car = Instantiate (playerCars[playerCarNumber], mapContainer.startPoints[0].position, Quaternion.identity);
       SceneManager.MoveGameObjectToScene(car, scene);
    }

    public void SetUpAiCars(Scene scene)
    {
        GameObject car;

        for(int i = 1; i <= mapContainer.startPoints.Length - 1; i++)
        {
            car = Instantiate(AICars[Random.Range(0, AICars.Length)], mapContainer.startPoints[i].position, Quaternion.identity);
            SceneManager.MoveGameObjectToScene(car, scene);
        }     
    }

    public float GreyScale()
    {
        Color newColor = new Color(0.3f, 0.4f, 0.6f);
        return newColor.grayscale;
    }
}
