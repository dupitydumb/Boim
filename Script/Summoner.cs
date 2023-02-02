using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : Enemy {
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 targetPosition;
    public float timeBetweenSummons;
    public Enemy EnemyToSummon;
    public float summonTime;
    public float attackspeed;
    public float stopDistance;
    Animator anim;
    private float timer;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        targetPosition = new Vector2(randomX, randomY);



        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                anim.SetBool("isRunning", true);
            } else {
                anim.SetBool("isRunning", false);
                if (Time.time >= summonTime)
                {
                    summonTime = Time.time + timeBetweenSummons;
                    anim.SetTrigger("summon");
                }
    
            }
        }

        if (Vector2.Distance(transform.position, player.position) < stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        

    }

    public void Summon()
    {
        if (player != null)
        {
            Instantiate(EnemyToSummon, transform.position, transform.rotation);
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
