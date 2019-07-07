using System.Collections;
using UnityEngine;

public class OrbPlacedTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        gameManager.CompleteGame();
    }

}
