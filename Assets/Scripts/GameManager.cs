using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum directionEnum
{
    up = 0,
    down = 1,
    left = 2,
    right = 3,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private List<Transform> floors;

    [SerializeField] private List<directionEnum> directionLevel;
    [SerializeField] private int level;
    [SerializeField] private Vector3 safePos = new Vector3(0, 0, 0);

    private int countRandom = 0;
    private int minPosition = -10;
    private int maxPosition = 10;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        level = 0;
        foreach (Transform transform in floors)
        {
            if (transform.position == safePos)
            {
                Debug.Log(transform.parent.gameObject.name + "  " + transform.gameObject.name);
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CreateDirectionLevel();
        }
    }
    private List<int> GetSafePosition()
    {
        List<int> possiblePos = new List<int>();
        possiblePos.Add((int)directionEnum.up);
        possiblePos.Add((int)directionEnum.down);
        possiblePos.Add((int)directionEnum.left);
        possiblePos.Add((int)directionEnum.right);

        if (safePos.x <= minPosition)
        {
            possiblePos.Remove((int)directionEnum.left);
        }
        else if (safePos.x >= maxPosition)
        {
            possiblePos.Remove((int)directionEnum.right);
        }
        if (safePos.z <= minPosition)
        {
            possiblePos.Remove((int)directionEnum.down);
        }
        else if (safePos.z >= maxPosition)
        {
            possiblePos.Remove((int)directionEnum.up);
        }

        return possiblePos;
    }
    public void CreateDirectionLevel()
    {
        level += 1;
        Menu.Instance.ShowLevel(level);
        directionLevel.Clear();
        RandomPos();
    }
    private void RandomPos()
    {
        countRandom += 1;
        List<int> possiblePos = GetSafePosition();
        directionEnum direction = (directionEnum)possiblePos[Random.Range(0, possiblePos.Count)];
        directionLevel.Add(direction);

        switch (direction)
        {
            case directionEnum.up:
                safePos = new Vector3 (safePos.x, safePos.y, safePos.z + 1);
                break;
            case directionEnum.down:
                safePos = new Vector3(safePos.x, safePos.y, safePos.z - 1);
                break;
            case directionEnum.left:
                safePos = new Vector3(safePos.x - 1, safePos.y, safePos.z);
                break;
            case directionEnum.right:
                safePos = new Vector3(safePos.x + 1, safePos.y, safePos.z);
                break;
        }
        if (countRandom < level)
        {
            RandomPos();
        }
        else
        {
            EndLevel();
        }
    }
    private void EndLevel()
    {
        countRandom = 0;
        Menu.Instance.GetDirectionList(directionLevel);
    }
}
