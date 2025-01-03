using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    float xInput;
    float yInput;
    private void Update()
    {
        GetMovementInput();
        MoveCharacter();
    }

    private void GetMovementInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void MoveCharacter()
    {
        transform.position += new Vector3(xInput * movementSpeed * Time.deltaTime, yInput * movementSpeed * Time.deltaTime, 0);
    }
}
