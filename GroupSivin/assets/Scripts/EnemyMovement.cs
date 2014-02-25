using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public bool checkLeft;
    public bool checkRight;
    public bool checkUp;
    public bool checkDown;

    public bool checkForRecyclingPlant;

    public bool moveUp;
    public bool moveDown;
    public bool moveRight;
    public bool moveLeft;

    public string previousMovement;

    int random1;
    int random2;

	int enemyWalkingSpeed = 3;

	// Use this for initialization
	void Start () {

        random1 = RandomNumber.GenerateRandomNumber(0, 20);

        if (random1 < 5)
            moveUp = true;

        if (random1 >= 5 && random1 <= 10)
            moveDown = true;

        if (random1 >= 10 && random1 <= 15)
            moveRight = true;

        if (random1 >= 15 && random1 <= 20)
            moveLeft = true;

	}
	
	// Update is called once per frame
	void Update () {

        CheckDirections();
        ChangeDirections();
        MoveEnemy();

	}

    void CheckDirections()
    {

        checkRight = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x + 0.3f, this.transform.position.y), 1 << LayerMask.NameToLayer("Wall"));
        checkLeft = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x - 0.3f, this.transform.position.y), 1 << LayerMask.NameToLayer("Wall"));
        checkUp = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y + 0.3f),   1 << LayerMask.NameToLayer("Wall"));
        checkDown = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y - 0.3f), 1 << LayerMask.NameToLayer("Wall"));

        checkForRecyclingPlant = Physics2D.Linecast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x + 0.3f, this.transform.position.y + 0.3f), 1 << LayerMask.NameToLayer("RecyclingPlant"));

        Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x + 0.3f, this.transform.position.y));
        Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x - 0.3f, this.transform.position.y));
        Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y + 0.3f));
        Debug.DrawLine(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(this.transform.position.x, this.transform.position.y - 0.3f));

    }

    void ChangeDirections()
    {

        

        if (checkDown && moveDown)
        {
            random2 = RandomNumber.GenerateRandomNumber(0, 15);

            if (random2 <= 5)
            {
                moveUp = true;
                moveLeft = false;
                moveDown = false;
                moveRight = false;
            }
            else if (random2 > 5 && random2 <= 10)
            {
                moveLeft = true;
                moveUp = false;
                moveDown = false;
                moveRight = false;
            }
            else
            {
                moveRight = true;
                moveLeft = false;
                moveDown = false;
                moveUp = false;
            }
        }

        if (checkUp && moveUp)
        {
            random2 = RandomNumber.GenerateRandomNumber(0, 15);

            if (random2 <= 5)
            {
                moveDown = true;
                moveLeft = false;
                moveUp = false;
                moveRight = false;
            }

            else if (random2 > 5 && random2 <= 10)
            {
                moveLeft = true;
                moveUp = false;
                moveDown = false;
                moveRight = false;
            }

            else
            {
                moveRight = true;
                moveLeft = false;
                moveDown = false;
                moveUp = false;
            }
        }

        if ((checkRight && moveRight))
        {
            random2 = RandomNumber.GenerateRandomNumber(0, 15);

            if (random2 <= 5)
            {
                moveUp = true;
                moveLeft = false;
                moveDown = false;
                moveRight = false;
            }

            else if (random2 > 5 && random2 <= 10)
            {
                moveLeft = true;
                moveUp = false;
                moveDown = false;
                moveRight = false;
            }

            else
            {
                moveDown = true;
                moveLeft = false;
                moveUp = false;
                moveRight = false;
            }

        }

        if ((checkLeft && moveLeft) || (checkForRecyclingPlant && moveLeft))
        {
            random2 = RandomNumber.GenerateRandomNumber(0, 15);

            if (random2 <= 5)
            {
                moveUp = true;
                moveLeft = false;
                moveDown = false;
                moveRight = false;
            }

            else if (random2 > 5 && random2 <= 10)
            {
                moveDown = true;
                moveLeft = false;
                moveUp = false;
                moveRight = false;
            }

            else
            {
                moveRight = true;
                moveLeft = false;
                moveDown = false;
                moveUp = false;
            }

        }

      
    }

    void MoveEnemy()
    {
        if (moveUp)
            rigidbody2D.velocity = new Vector2(0, enemyWalkingSpeed);
        else if (moveDown)
            rigidbody2D.velocity = new Vector2(0, -enemyWalkingSpeed);
        else if (moveRight)
            rigidbody2D.velocity = new Vector2(enemyWalkingSpeed, 0);
        else if (moveLeft)
            rigidbody2D.velocity = new Vector2(-enemyWalkingSpeed, 0);
    }

   
}