using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class RockText : MonoBehaviour
{
    public TextMeshProUGUI textBox;
    public string[] lines;
    public float textSpeed;
    int index;

    void Start()
    {
        textBox.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textBox.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textBox.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textBox.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textBox.text = string.Empty;
            StartCoroutine (TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);
        }
    }
}
