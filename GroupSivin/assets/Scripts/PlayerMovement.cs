using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    static float speed = 4;

	public GameObject trash;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

        MovePlayer();
        LockCameraToPlayer();

		if (speed < 2.0f)
			speed = 2.0f;

	}
	

	public static void ResetSpeed()
	{
		speed = 4;
	}

	public static void ChangeSpeed(float delta){

		speed += delta;

	}
	

    void MovePlayer()
    {
        if (Input.GetKey(KeyCode.W))
            this.rigidbody2D.velocity = (new Vector2(0, speed));

        else if (Input.GetKey(KeyCode.S))
            this.rigidbody2D.velocity = (new Vector2(0, -speed));

        else if (Input.GetKey(KeyCode.D))
            this.rigidbody2D.velocity = (new Vector2(speed, 0));

        else if (Input.GetKey(KeyCode.A))
            this.rigidbody2D.velocity = (new Vector2(-speed, 0));

        else
            rigidbody2D.velocity = new Vector2(0, 0);
    }

    void LockCameraToPlayer()
    {

        Camera.main.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, Camera.main.transform.position.z);

    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")
        {
			if(PlayerScore.Score >= 5)
			{
				PlayerMovement.ChangeSpeed(0.5f);
			}
			else
			{
				PlayerMovement.ChangeSpeed(0.1f * PlayerScore.Score);
			}

			PlayerScore.ChangeScore(-5);
        }
    }
}
