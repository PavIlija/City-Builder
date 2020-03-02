using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] // privatna polja se prikazuju u inspectoru 
    private Text dayText;
    [SerializeField]
    private Text cityText;
    private City city;

    


    // Start is called before the first frame update
    void Start()
    {
        city = this.GetComponent<City>();
    }

    public void UpdateCityData()
    {
        cityText.text = string.Format("Jobs: {0}/{1}\nCash: {2}\nPopulation: {3}/{4}\nFood: {5}",
            city.JobsCurrent, city.JobsCeiling, city.Cash, city.PopulationCurrent, 
            city.PopulationCeiling, city.Food);
    }

    public void UpdateDayCount()
    {
        dayText.text = string.Format("Day {0}", city.Day);
    }
}
