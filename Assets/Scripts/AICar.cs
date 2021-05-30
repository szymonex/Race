using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AICar : MonoBehaviour
{
    public Transform targetNavPoint;
    public float speedFactor;
    public AITrack aiTrack;
    public float rotationFactor;
    public int currentNavPointIndex;
    public GameObject NavPointPrefab;
    GameObject randomizedNavPoint = null;

    //public float SpeedFactor { get { return speedFactor; } set { speedFactor = value; } }

    // Start is called before the first frame update
    void Start()
    {
        //aiTrack = GameObject.Find("AI_NavPoints").GetComponent<AITrack>();
        aiTrack = GameObject.FindObjectOfType<AITrack>();
        if(aiTrack == null)
        {
            Debug.Log("Obiekt typu AITrack nie został znaleziony");
        }
        currentNavPointIndex = 0;
        targetNavPoint = aiTrack.navPoints[currentNavPointIndex];
        //NavPointPrefab = GameObject.Find("NP1");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = targetNavPoint.position - transform.position;
        float angle = Vector3.Angle(transform.up, toTarget); // angle zwraca kąt pomiędzy dwoma wektorami
        //cross-product - wektor który jest prostopadły do mnożonych wektorów, jego długość jest pomnożeniem jednego wektora razy drugi razy kont między nimi i w zależności czy wynik jest dodatni czy ujemny dostajemy informację czy kąt jest mierzony w prawo czy w lewo
        Vector3 cross = Vector3.Cross(transform.up, toTarget);
        if(cross.z < 0)
        {
            angle = -angle;
        }
        transform.Rotate(0f, 0f, angle * rotationFactor * Time.deltaTime);
        transform.Translate(0f, speedFactor * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform == targetNavPoint)
        {
            //collision.enabled = false;
            //currentNavPointIndex++;
            //currentNavPointIndex = (int)Mathf.Repeat(currentNavPointIndex, aiTrack.navPoints.Length); //żeby nie przekroczyć zakresu tablicy
            targetNavPoint = GetNextNavPoint();
            Vector2 randomizedPosition = (Vector2)targetNavPoint.position + Random.insideUnitCircle; //rzutowanie żeby zunifikować Vecory bo jeden był Vector3 a drugi Vector2 i wywalało błąd
            //GameObject randomizedNavPoint = Instantiate(NavPointPrefab);
            if(randomizedNavPoint != null)
            {
                Destroy(randomizedNavPoint);
            }
            randomizedNavPoint = Instantiate(NavPointPrefab);
            randomizedNavPoint.transform.position = randomizedPosition;
            targetNavPoint = randomizedNavPoint.transform;
            //Destroy(randomizedNavPoint, 6f);
            //StartCoroutine("TurnOnCollider", collision); //wywołanie korutyny i przekazanie mu w parametrze Collider2D collision
        }
    }

    public Transform GetNextNavPoint()
    {
        if (currentNavPointIndex < aiTrack.navPoints.Length - 1)
        {
            currentNavPointIndex++;
        }
        else
        {
            currentNavPointIndex = 0;
        }

        return aiTrack.navPoints[currentNavPointIndex];
    }

    //korutyna
    //IEnumerator TurnOnCollider(Collider2D collision)
    //{
    //    yield return new WaitForSeconds(3); //opóźnienie
    //    collision.enabled = true;
    //}
}
