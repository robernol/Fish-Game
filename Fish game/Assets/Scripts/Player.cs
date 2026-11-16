using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject rock, rod, stairs, fadeScreen;
    public SpriteRenderer rockIndicator, rodIndicator, stairsIndicator;
    public bool endDay, canMove;
    public float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endDay = false;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (endDay)
        {
            Wait();
        }
        else 
        {
            if (canMove)
            {
                PlayerMovement();
            }
        }

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject == rod))
        {
            if ((Input.GetKey(KeyCode.E)) && (!endDay)) 
            {
                Debug.Log("Fishing");
                SceneManager.LoadScene("Fishing");
                //SceneManager.LoadScene("Rock", LoadSceneMode.Additive);
                //canMove = false;
            }

        }

        if ((collision.gameObject == rock))
        {
            if ((Input.GetKey(KeyCode.E)) && (!endDay))
            {
                Debug.Log("Rock");
                SceneManager.LoadScene("Rock");
                //SceneManager.LoadScene("Rock", LoadSceneMode.Additive);
                //canMove = false;
            }

        }

        if ((collision.gameObject == stairs))
        {
            if ((Input.GetKey(KeyCode.E)) && (!endDay))
            {
                Debug.Log("Bye Bye");
                fadeScreen.GetComponent<FadeOut>().TriggerFade(true);
                endDay = true;
                timer = Time.time + 3f;
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject == rod))
        {
            rodIndicator.enabled = true;
        }

        if ((collision.gameObject == rock))
        {
            rockIndicator.enabled = true;
        }

        if ((collision.gameObject == stairs))
        {
            stairsIndicator.enabled = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.gameObject == rod))
        {
            rodIndicator.enabled = false;
        }

        if ((collision.gameObject == rock))
        {
            rockIndicator.enabled = false;
        }

        if ((collision.gameObject == stairs))
        {
            stairsIndicator.enabled = false;
        }
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }
    }

    void Wait()
    {
        if (Time.time > timer)
        {
            fadeScreen.GetComponent<FadeOut>().TriggerFade(false);
            endDay = false;
        }
    }
}
