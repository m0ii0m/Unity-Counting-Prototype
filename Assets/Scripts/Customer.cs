using TMPro;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public TextMeshProUGUI meshText;
    public GameObject dialogueScene;
    public ScoreManager scoreManager;

    [SerializeField] float speed;

    private string text;
    private bool state1;
    private bool state2;
    private bool accept;
    private bool reject;
    private bool acceptable;
    private string[] texts = new string[]
    {
        "I want a room filled with enchanted pillows.",
        "I need a bathtub full of bee blood.",
        "I only sleep in zero gravity.",
        "Do you accept guests shaped like triangles?",
        "I eat the other guests’ pillows."
    };

    // Start is called before the first frame update
    void Start()
    {
        state1 = true;
        state2 = false;
        accept = false;
        reject = false;
        text = texts[Random.Range(0, texts.Length)];
        acceptable = text.Contains("pillows") || text.Contains("gravity");
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreManager.gameOver) {
            Destroy(gameObject);
            return;
        }

        if (state1)
        {
            if (transform.position.z < 7.25f)
            {
                state1 = false;
                state2 = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, 7.25f);
            }
            else
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }

        }
        if (state2)
        {
            if (transform.position.x < 7)
            {
                state2 = false;
                meshText.text = text;
                dialogueScene.SetActive(true);
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }
        if (accept)
        {
            if (transform.position.z > 16.5f)
            {
                accept = false;
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
            }
        }
        if (reject)
        {
            if (transform.position.z < -2)
            {
                reject = false;
                Destroy(gameObject);
            }
            else
            {
                transform.Translate(Vector3.back * Time.deltaTime * speed);
            }
        }
    }

    public void Accept()
    {
        if (acceptable) scoreManager.AddScore(1);
        else scoreManager.AddScore(-2);
        dialogueScene.SetActive(false);
        accept = true;
    }

    public void Reject()
    {
        if (!acceptable) scoreManager.AddScore(1);
        else scoreManager.AddScore(-2);
        dialogueScene.SetActive(false);
        reject = true;
    }
}