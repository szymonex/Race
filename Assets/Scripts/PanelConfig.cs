using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfig : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lapsText;
    [SerializeField] LapsSystem lapsSystem;
    [SerializeField] Slider sliderLaps;

    int playerCarNumber = 0;
    [SerializeField] GameObject[] playerCars;
    [SerializeField] GameObject[] AICars;
    [SerializeField] Transform[] startPoints;

    void Start()
    {
        Time.timeScale = 0f;

        lapsSystem = (LapsSystem)GameObject.FindObjectOfType(typeof(LapsSystem)); //będzie znaleziony pierwszy obiekt tego typu, zakładamy więc najlepiej, że mamy tylko jeden obiekt tego typu
        if (lapsSystem == null)
        {
            Debug.LogError("LapsSystem is null in script PanelConfig!!!");
        }
    }

    public void UpdateText(float value)
    {
        lapsText.text = value.ToString();
    }

    public void StartRace()
    {
        lapsSystem.ConfigureRace(Mathf.RoundToInt(sliderLaps.value)); //zaokrąglamy float do int
        Time.timeScale = 1f;
        SetUpPlayerCar();
        SetUpAiCars();
        gameObject.SetActive(false);
    }

    public void SetPlayerCarNumber(int carNumber)
    {
        playerCarNumber = Mathf.Clamp(carNumber, 0, playerCars.Length - 1);
    }

    public void SetUpPlayerCar()
    {
        Instantiate(playerCars[playerCarNumber], startPoints[0].position, Quaternion.identity);
    }

    public void SetUpAiCars()
    {
        for(int i = 1; i <= startPoints.Length - 1; i++)
        {
            Instantiate(AICars[Random.Range(0, AICars.Length)], startPoints[i].position, Quaternion.identity);
        }
        
    }
}
