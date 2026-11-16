using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class FishingController : MonoBehaviour
{
    public GameObject fishDisplay;
    public SpriteRenderer bobber, hook;
    public bool cast, biting;
    float biteTimer;

    void Start()
    {
        cast = false;
        biting = false;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!cast)
            {
                cast = true;
                bobber.enabled = true;
                hook.enabled = false;
            }
            else if (biting)
            {
                cast = false;
                biting = false;
                bobber.enabled = false;
                hook.enabled = true;
                fishDisplay.GetComponent<Fishing>().CatchFish();

            }
            else
            {
                cast = false;
                bobber.enabled = false;
                hook.enabled = true;
            }
        }

        if (cast)
        {
            CastCheck();
        }

        if (biting)
        {
            if (Time.time > biteTimer)
            {
                biting = false;
                bobber.enabled = true;
            }
        }

        if (!cast)
        {
            TrackMouse();
        }
    }

    void TrackMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -1f;
        if (mousePos.y > 0.5f)
        {
            mousePos.y = 0.5f;
        }

        transform.position = mousePos;
    }

    void CastCheck()
    {
        int x = Random.Range(0, 2000);
        if (x == 0)
        {
            biting = true;
            bobber.enabled = false;
            biteTimer = Time.time + 1.5f;
        }
    }
}
