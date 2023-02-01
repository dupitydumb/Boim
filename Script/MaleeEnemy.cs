using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaleeEnemy : Enemy
{
    // Start is called before the first frame update

    public float stopDistance;
    private float attackTime;

    public float attackspeed;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, player.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= attackTime)
                {
                    StartCoroutine(Attack());
                    //Attack
                    attackTime = Time.time + timeBetweenAttack;
                }
            }
        }

        IEnumerator Attack()
        {
            player.GetComponent<Player>().TakeDamage(damage);
            //Play attack animation
            //Wait for animation to finish
            yield return new WaitForSeconds(1f);

            Vector2 originalPosition = transform.position;
            Vector2 targetPosition = player.position;

            float percent = 0;
            while (percent <= 1)
            {
                percent += Time.deltaTime * attackspeed;
                float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
                transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
                yield return null;
            }
            //Damage player
        }
    }
}
