using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public GameObject dialogueScene;
    public ScoreManager scoreManager;
    public Button acceptButton;
    public Button rejectButton;
    [SerializeField] GameObject customerPrefab;
    [SerializeField] Vector3 startPos = new Vector3(20, 1.75f, 32f);

    // Start is called before the first frame update
    void Start()
    {
        SpawnCustommer();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreManager.gameOver) return;

        if (FindObjectsOfType<Customer>().Length == 0)
        {
            SpawnCustommer();
        }
    }

    void SpawnCustommer()
    {
        Instantiate(customerPrefab, startPos, customerPrefab.transform.rotation);
        Customer customer = FindObjectOfType<Customer>();
        customer.meshText = textMesh;
        customer.dialogueScene = dialogueScene;
        customer.scoreManager = scoreManager;
        acceptButton.onClick.RemoveAllListeners();
        rejectButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => customer.Accept());
        rejectButton.onClick.AddListener(() => customer.Reject());
    }
}
