using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTirggerArea : MonoBehaviour
{
    private Enemy enemyParent;

    private void Awake()
    {
        enemyParent = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = collider.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
