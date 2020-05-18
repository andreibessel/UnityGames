using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float MovementSpeed;
    public float ExtraSpeedPerHit;
    public float MaxExtraSpeed;
    private int HitCounter;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
        
    }
    void PositionBall(bool isPlayer1Starting)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        if (isPlayer1Starting)
        {
            this.gameObject.transform.position = new Vector3(-100, 0, 0);

        }
        else
        {
            this.gameObject.transform.position = new Vector3(100, 0, 0);

        }
    }
    public IEnumerator StartBall(bool isStrartingPlayer1 = true)
    {

        this.PositionBall(isStrartingPlayer1);

        this.HitCounter = 0;

        yield return new WaitForSeconds(2);

        if (isStrartingPlayer1)
            this.MoveBall(new Vector2(-1,0));
        else
        {
            this.MoveBall(new Vector2(1, 0));

        }
    }
     
    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.MovementSpeed + this.ExtraSpeedPerHit * this.HitCounter;

        Rigidbody2D rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = dir * speed;

    }
    public void IncreaseHitCounter()
    {
        if (this.HitCounter * this.ExtraSpeedPerHit < this.MaxExtraSpeed)
        {
            this.HitCounter++;
        }
    }
}
