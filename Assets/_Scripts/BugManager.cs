using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct BugPit
{
    public ColorType colorType;
    public int maxCount;
    public int currentCount;
}

public class BugManager : MonoBehaviour
{
    public Vector3 minBounds;
    public Vector3 maxBounds;

    [Header("Win Condition")]
    [SerializeField]
    private BugPit[] bugPits;

    [Header("Bug Properties")]
    public GameObject bugPrefab;
    public Material[] materials;

    [Header("UI Elements")]
    public GameObject[] panels;
    [SerializeField]
    private Sprite[] colorIcon;

    public static BugManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        bugPits = new BugPit[3];

        InitiatePits();

        InitializeUI();

        SpawnBugs();
    }

    private void InitiatePits()
    {
        for (int i = 0; i < 3; i++)
        {
            BugPit pit;
            pit.colorType = (ColorType)Random.Range(0, (int)ColorType.COUNT);

            // Make sure you get three different colors
            if(i == 1)
            {
                while(pit.colorType == bugPits[0].colorType)
                {
                    pit.colorType = (ColorType)Random.Range(0, (int)ColorType.COUNT);
                }
            }
            else if(i == 2)
            {
                while (pit.colorType == bugPits[0].colorType || pit.colorType == bugPits[1].colorType)
                {
                    pit.colorType = (ColorType)Random.Range(0, (int)ColorType.COUNT);
                }
            }

            pit.maxCount = Random.Range(10, 16);
            pit.currentCount = 0;

            bugPits[i] = pit;
        }
    }

    private void InitializeUI()
    {
        for(int i = 0; i < 3; i++)
        {
            panels[i].transform.GetChild(0).GetComponent<Image>().sprite = colorIcon[(int)bugPits[i].colorType];
            panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = bugPits[i].currentCount.ToString("00") + " / " + bugPits[i].maxCount;
        }
    }

    private void SpawnBugs()
    {
        foreach(BugPit bp in bugPits)
        {
            for(int i = 0; i < bp.maxCount; i++)
            {
                Vector3 pos = new Vector3(Random.Range(minBounds.x, maxBounds.x), 0.25f, Random.Range(minBounds.z, maxBounds.z));
                GameObject bug = Instantiate(bugPrefab, pos, Quaternion.identity);

                Material[] mat = new Material[1];
                mat[0] = materials[(int)bp.colorType];
                bug.transform.GetChild(0).GetComponent<SkinnedMeshRenderer>().materials = mat;

                bug.GetComponent<BugBehaviour>().colorType = bp.colorType;
            }
        }
    }

    public void IncrementBugCount(ColorType color, int count)
    {
        for(int i = 0; i < 3; i++)
        {
            if (bugPits[i].colorType != color)
                continue;

            bugPits[i].currentCount += count;
            bugPits[i].currentCount = bugPits[i].currentCount > bugPits[i].maxCount ? bugPits[i].maxCount : bugPits[i].currentCount;
            panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = bugPits[i].currentCount.ToString("00") + " / " + bugPits[i].maxCount;
        }
    }

    public void SetBugCount(ColorType color, int value)
    {
        for (int i = 0; i < 3; i++)
        {
            if (bugPits[i].colorType != color)
                continue;

            bugPits[i].currentCount = value;
            panels[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = bugPits[i].currentCount.ToString("00") + " / " + bugPits[i].maxCount;
        }
    }
}
