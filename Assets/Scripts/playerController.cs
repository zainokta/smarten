using UnityEngine;

public class playerController : MonoBehaviour {

    public Animator anim;
    private float speed;
    private Rigidbody2D myRB;
    public Camera cam;
	void Start () {
        myRB = GetComponent<Rigidbody2D>();
        speed = 4f;
	}

    void Update () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        myRB.velocity = new Vector2(moveX * speed, moveY * speed);
        if(moveX > 0)
        {
            anim.Play("PlayerRight");
        }
        else if (moveX < 0)
        {
            anim.Play("PlayerLeft");
        }
        else if(moveY > 0)
        {
            anim.Play("PlayerUp");
        }
        else
        {
            anim.Play("PlayerIdle");
        }
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minScreenBounds.x + 0.5f, maxScreenBounds.x - 0.5f), Mathf.Clamp(transform.position.y, minScreenBounds.y + 0.5f, maxScreenBounds.y - 0.5f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            sceneManager.instance.level += 1;
            sceneManager.instance.LoadScene();
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(cam, transform.position, Quaternion.identity);
        }
    }
}