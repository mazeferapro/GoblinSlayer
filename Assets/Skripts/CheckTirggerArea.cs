using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTirggerArea : MonoBehaviour
{
    private Enemy enemyParent;

    private void Awake()
    {
        enemyParent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            enemyParent.target = col.transform;
            enemyParent.inRange = true;
            enemyParent.hotZone.SetActive(true);
        }
    }
}
