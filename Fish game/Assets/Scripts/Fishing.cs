using UnityEngine;
using TMPro;

public class Fishing : MonoBehaviour
{
    public TMP_Text fishText;
    public Sprite[] sprites;
    float timer;
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.time > timer)
        {
            fishText.enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    public void CatchFish()
    {
        fishText.enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        int fish = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[fish];
        fishText.text = sprites[fish].name;
        timer = Time.time + 2;

    }
}
