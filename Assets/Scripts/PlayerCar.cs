using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCar : MonoBehaviour
{
    Transform carTransform;
    Rigidbody2D rBody2D;
    [SerializeField] float forceFactor = 0f; // wcześniej speedFactor
    
    public float ForceFactor { get { return forceFactor; } set { forceFactor = value; } }
    [SerializeField] float rotateSpeedFactor = 0f;

    // Start is called before the first frame update
    void Start() // w pierwszej klatce
    {
        carTransform = GetComponent<Transform>();
        rBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() // wykonuje się co stałą jednostkę czasu, tu NIE TRZEBA Time.deltaTime
    {
        float vAxis = Input.GetAxis("Vertical");
        Vector3 offsetPosition = transform.position + transform.up * 0.47f;

        // rBody2D.AddRelativeForce(new Vector2(0f, vAxis *forceFactor)); // AddForce przykład siłę do układu globalnego, czyli np y bedzie zawsze w góre, AddRelativeForce przykłada siłę w układzie lokalnym!
        //transform.up - to stały wektor y jednostkowy (o długości 1) względem lokalnego układu współrzędnych
        rBody2D.AddForceAtPosition(transform.up * vAxis * forceFactor, offsetPosition); //AddRelativeForce przykłada siłę zawsze na srodku obiektu, a AddForceAtPosition w konkretnym punkcie. Można zrobić np napęd na tył lub przód pojazdu!

        Debug.DrawLine(offsetPosition, offsetPosition + (transform.up * vAxis * forceFactor), Color.magenta); //(miejsce przyłożenia, miejsce przyłożenia + długość wektora)
        Debug.DrawLine(offsetPosition, offsetPosition + (Vector3)rBody2D.velocity, Color.yellow); //rBody2D. velocity to wektor prędkości

        float hAxis = Input.GetAxis("Horizontal");
        if (rBody2D.velocity.magnitude > 1f) // można też !Mathf.Approximately(rBody2D.velocity.magnitude, 0)
        {
            carTransform.Rotate(0f, 0f, hAxis * -rotateSpeedFactor * Time.deltaTime); // minus żeby się nie kręcił odwrotnie
        }
        else
        {
            carTransform.Rotate(0f, 0f, hAxis * -rotateSpeedFactor * Time.deltaTime * rBody2D.velocity.magnitude); //czyli przemnazamy przez magnitude gdy wiemy, że ma wartość poniżej 1
        }

    }

    // Update is called once per frame
    //void Update() // tak często jak tylko się da "ile fabryka dała ;)"
    //{
    //    float vAxis = Input.GetAxis("Vertical");
    //    carTransform.Translate(0f, vAxis * speedFactor * Time.deltaTime, 0f); // deltaTime - czas w jakim została wykonana poprzednia klatka
    //    if(vAxis != 0)
    //    {
    //        isMove = true;
    //    }
    //    else
    //    {
    //        isMove = false;
    //    }
    //    float hAxis = Input.GetAxis("Horizontal");
    //    if(isMove == true)
    //    {
    //        carTransform.Rotate(0f, 0f, hAxis * -rotateSpeedFactor * Time.deltaTime); // minus żeby się nie kręcił odwrotnie
    //    }

    //}
}
