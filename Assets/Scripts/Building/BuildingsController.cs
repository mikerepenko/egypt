using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsController : MonoBehaviour
{
    [SerializeField] private GameObject buildingPlay;
    [SerializeField] private GameObject buildingClosed;

    [SerializeField] private List<GameObject> buildings;

    [SerializeField] public TextAsset jsonFile;

    private Buildings buildingsInJson;
    private int currLevel;

    private void Awake()
    {
        PlayerPrefs.SetInt("level", 2);
    }

    private void Start()
    {
        currLevel = PlayerPrefs.GetInt("level");
        buildingsInJson = JsonUtility.FromJson<Buildings>(jsonFile.text);

        ParseBuildings(currLevel);
    }

    public void ParseBuildings(int currLevel)
    {
        foreach (GameObject b in buildings)
        {
            foreach (Building building in buildingsInJson.buildings)
            {
                if (b.name == building.name)
                {
                    if (currLevel >= building.minLevel)
                    {
                        //b.SetActive(true);
                        //Sprite change built
                    }
                    else
                    {
                        //b.SetActive(false);
                        //Sprite change destroyed
                    }
                }
            }
        }
    }

    public void ClickOnBuilding(string name)
    {
        foreach (Building building in buildingsInJson.buildings)
        {
            if (name == building.name)
            {
                if (building.minLevel <= currLevel)
                {
                    buildingPlay.SetActive(true);
                    return;
                }

                buildingClosed.SetActive(true);
            }
        }
    }
}
