using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    //properti pristupaju privatnim promenljivima koje postoje ali se ne vide --private int cash
    public int Cash { get; set; } 
    public int Day { get; set; }
    public float PopulationCurrent { get; set; }
    public float PopulationCeiling { get; set; }
    public int JobsCurrent { get; set; }
    public int JobsCeiling { get; set; }
    public float Food { get; set; }

    private UIcontroller uIcontroller;
    public int [] buildingCounts = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        uIcontroller = this.GetComponent<UIcontroller>();
        buildingCounts[0] = 4;
        buildingCounts[1] = 2;
        buildingCounts[2] = 3;
        Cash = 1000;
        Food = 6;
        JobsCeiling = 10;
    }

    public void EndTurn()
    {
        Day++;
        CalculatePopulation();
        CalculateJobs();
        CalculateCash();
        CalculateFood();
        Debug.Log("Day ended");
        Debug.LogFormat("Jobs: {0}/{1}, Cash: {2}, pop: {3}/{4}, Food:{5}",
            JobsCurrent,JobsCeiling, Cash, PopulationCurrent,PopulationCeiling, Food);
        ;
        uIcontroller.UpdateCityData();
        uIcontroller.UpdateDayCount();
    }

    void CalculateJobs()
    {
        JobsCeiling = buildingCounts[2] * 10;
        JobsCurrent = Mathf.Min((int) PopulationCurrent,JobsCeiling);
    }
    void CalculateCash()
    {
        Cash += JobsCurrent * 2;
    }

    void CalculateFood()
    {
        Food += buildingCounts[1] * 4f;
        JobsCurrent = Mathf.Min((int)PopulationCurrent, JobsCeiling);
    }
    
    void CalculatePopulation()
    {
        PopulationCeiling = buildingCounts[0] * 5;
        if(Food >= PopulationCurrent && PopulationCurrent<PopulationCeiling)
        {
            Food -= PopulationCurrent *.25f;
            PopulationCurrent = Mathf.Min(PopulationCurrent += Food * .25f, PopulationCeiling);
        }
        else if (Food<PopulationCurrent)
        {
            PopulationCurrent -= (PopulationCurrent-Food)* .5f;
        }
    }


}
