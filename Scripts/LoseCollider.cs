using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool playerLost;
    void Start()
    {
        playerLost = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ball") {
            StartCoroutine(WaitAndEndRoutine());
        }
    }

    private IEnumerator WaitAndEndRoutine() {
        yield return new WaitForSeconds(1f);
        playerLost = true;
    }
}
