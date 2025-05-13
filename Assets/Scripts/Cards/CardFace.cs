using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFace : MonoBehaviour
{
    public GameObject target;

    public float rotationSpeed;
    public float rotationAmount;
    Vector3 movement;
    public string cardCode; //to check if can connect with other card


    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * 25);

        if (!target.GetComponent<Card>().Played)
        {   
            Vector3 pos = (transform.position - target.transform.position);
            //Vector3 movementRotation;
            
            movement = Vector3.Lerp(movement, pos, 25 * Time.deltaTime);
            
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y); //
        }

    }
}
