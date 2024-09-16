using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public TextAsset jsonFile;
    public VisuData Visualize;
    void Start()
    {
            Cities employeesInJson = JsonUtility.FromJson<Cities>(jsonFile.text);
            foreach (City cities in employeesInJson.cities){
            Visualize.VisualCube(
                cities.lat,
                cities.lng,
                cities.population,
                Visualize.multiplier
            );
    }
}
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
