using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMotion : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float timeToCompleteCircle;

    private float currentAngle;

    [SerializeField]
    private float radius;
    
    [SerializeField]
    private string direction;
    
    private Vector3 objectDirection;
    private Quaternion objectRotation;

    private Quaternion toRotation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = (Mathf.PI * 2) / timeToCompleteCircle;
        float x;
        float z;
        switch (direction)
        {
            case "left":
                currentAngle += Time.deltaTime * speed;
                x = radius * Mathf.Cos(currentAngle);
                z = radius * Mathf.Sin(currentAngle);
                transform.localPosition = new Vector3(x, transform.localPosition.y, z);
                objectDirection = transform.forward - transform.position;
               
                toRotation = Quaternion.LookRotation(objectDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 15 *Time.deltaTime);
                break;
            
            case "right":
                currentAngle += Time.deltaTime * speed;
                x = radius * Mathf.Cos(currentAngle);
                z = radius * Mathf.Sin(currentAngle);
                transform.localPosition = new Vector3(-x, transform.localPosition.y, z);
                objectDirection = transform.forward - transform.position;
                
                toRotation = Quaternion.LookRotation(objectDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 15 * Time.deltaTime);
                break;
        }
    }
}
