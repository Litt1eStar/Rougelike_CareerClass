using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    [SerializeField] private float expValue = 10f;
    [SerializeField] private float moveSpeed = 20f;

    private bool isMoving = false;
    public void MoveTo(Vector3 destinationPosition)
    {
        if (!isMoving)
        {
            StartCoroutine(AnimateExp(destinationPosition));
        }
    }

    private IEnumerator AnimateExp(Vector3 destinationPosition)
    {
        isMoving = true;
        while (Vector3.Distance(this.transform.position, destinationPosition) > 0.1f)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, destinationPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        this.transform.position = destinationPosition;
        isMoving = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().AddExp(expValue);
            Destroy(this.gameObject);
        }
    }
}
