using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject fade, rock, rod, stairs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
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

    void onTriggerStay2D(Collider2D collision)
    {
        Debug.Log("collision with " + collision.gameObject.name);
        if ((collision.gameObject == rod) && (Input.GetKey(KeyCode.E)))
        {
            SceneManager.LoadScene("Fishing");
        }
        if ((collision.gameObject == rock) && (Input.GetKey(KeyCode.E)))
        {
            SceneManager.LoadScene("Rock");
        }
        if ((collision.gameObject == stairs) && (Input.GetKey(KeyCode.E)))
        {
            fade.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
