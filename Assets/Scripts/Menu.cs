using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Menu : MonoBehaviour
{
    public static Menu Instance;

    [SerializeField] private Button startButton;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Transform arrow;

    [SerializeField] private List<directionEnum> directionLevel;

    private string levelString = "Level ";
    private string animationArrow = "Arrow";
    private int countShowArrow;
    private bool isTiming = false;
    private float time;
    private float endTime = 1;

    private Vector3 upRotation = new Vector3(0, 0, 0);
    private Vector3 downRotation = new Vector3(0, 0, 180);
    private Vector3 leftRotation = new Vector3(0, 0, 90);
    private Vector3 rightRotation = new Vector3(0, 0, -90);
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartGame();
        }
        if (isTiming)
        {
            time += Time.deltaTime;
            if (time > endTime)
            {
                time = 0;
                isTiming = false;
                CheckDirectionLevel();
            }
        }
    }
    private void StartGame()
    {
        startButton.gameObject.SetActive(false);
        GameManager.Instance.CreateDirectionLevel();
    }
    public void ShowLevel(int level)
    {
        levelText.text = levelString + level;
    }
    public void GetDirectionList(List<directionEnum> direction)
    {
        directionLevel = direction;
        CheckDirectionLevel();
    }
    private void ShowArrow()
    {
        switch (directionLevel[countShowArrow])
        {
            case directionEnum.up:
                arrow.rotation = Quaternion.Euler(upRotation);
                break;
            case directionEnum.down:
                arrow.rotation = Quaternion.Euler(downRotation);
                break;
            case directionEnum.left:
                arrow.rotation = Quaternion.Euler(leftRotation);
                break;
            case directionEnum.right:
                arrow.rotation = Quaternion.Euler(rightRotation);
                break;
        }
        arrow.GetComponent<Animator>().Rebind();
        arrow.GetComponent<Animator>().Play(animationArrow);
        countShowArrow += 1;
        isTiming = true;
    }
    private void CheckDirectionLevel()
    {
        if (countShowArrow < directionLevel.Count)
        {
            ShowArrow();
        }
        else
        {
            countShowArrow = 0;
        }
    }
}
