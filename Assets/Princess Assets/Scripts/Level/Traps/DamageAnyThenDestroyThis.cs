using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrincessAdventure
{
    public class DamageAnyThenDestroyThis : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player") && collision.gameObject.layer == 6)
            {
                GameManager.GameInstance.DamagePrincess(this.transform.position);
            }
            else if (collision.CompareTag("Companion"))
            {
                GameManager.GameInstance.ActivatePrincess(true);
            }
            else if (collision.CompareTag("Enemy"))
            {
                EnemyActionController enemyCtrl = collision.GetComponent<EnemyActionController>();

                enemyCtrl.DamageEnemy(this.transform.position, false);
            }


        }
    }
}
