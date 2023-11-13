using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHighlight : MonoBehaviour
{
    public float rotationSpeed = 180f; 

    private void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
