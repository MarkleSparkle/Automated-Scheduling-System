using System;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleList : MonoBehaviour 
{
    //Detail View Section
    public GameObject SiteNameObject;//Text - TextMeshPro
    public GameObject OperatorTextObject;
    public GameObject DateObject;

    //Pins
    public GameObject CranstonMarket, DeerfootMeadows1, DeerfootMeadows2, DeerValley, HeritageMeadows, McKenzie, MillrisePlaza,
        RichmondRoad, Riverbend, Seton, ShawnessyGasBar, ShawnessyTowneCentre, SignalHill, SouthTrailCrossing, SouthcentreMall,
        SouthlandMacleod, Westhills;

    public Sprite OrangePin, GreenPin, BluePin;

    private static List<Schedule> scheduleList = new List<Schedule>();
    
    /**
     * Adds a schedule
     */
    public static void add(Schedule schedule)
    {
        scheduleList.Add(schedule);
    }

    /**
     * Gets the Schedule at a specific date
     * if not found, returns null
     */
    public Schedule get(DateTime date)
    {
        for(int i=0; i<scheduleList.Count; i++)
        {
            Debug.Log("COMPARING DATES: " + scheduleList[i].getDate() + " AND " + date);
            if(scheduleList[i].getDate() == date)//comparing the enumerator of Date inside of one schedule and another
            {
                return scheduleList[i];
            }
        }

        //if no Schedule of this Date is found, return null
        return null;
    }


    /**
     * Populates the map with info
     * TODO - If schedule is null (no generated schedule), pins are set to Orange, 
     * and data in detail fields are set to empty
     * 
     * ASSUMES SelectedDate is SET
     */
    public void populateMap()
    {
        //gets SelectedTime
        DateTime selectedDate = SelectedDate.getSelectedDate();

        //gets Schedule from scheduleList that matches the selectedDate
        Schedule schedule = get(selectedDate);

        Debug.Log("DATE COMPARE: Schedule - " + schedule.getDate() + " TO SelectedDate - " + selectedDate);

        if (schedule != null) {
            Dictionary<Site, Operator> siteOperatorPair = schedule.getPairs();//getting the Dictionary from the Schedule
            Dictionary<Site, Operator>.KeyCollection keys = siteOperatorPair.Keys;//getting all the keys in the Dictionary

            //changing all the Pins that have pairs (operators) to green pins
            foreach (Site key in keys)
            {//iterating through all of the keys in the Dictionary
                string siteNameString = siteOperatorPair[key].getName();//name of Site

                //if the string matches a Site name change its sprite to GreenPin
                switch (siteNameString)
                {
                    case "Cranston Market":
                        CranstonMarket.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Deer Valley":
                        DeerValley.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Deerfoot Meadows I":
                        DeerfootMeadows1.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Deerfoot Meadows II":
                        DeerfootMeadows2.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Heritage Meadows":
                        HeritageMeadows.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "McKenzie":
                        McKenzie.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Millrise Plaza":
                        MillrisePlaza.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Richmond Road":
                        RichmondRoad.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Riverbend":
                        Riverbend.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Seton":
                        Seton.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Shawnessy Gas Bar":
                        ShawnessyGasBar.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Shawnessy Towne Centre":
                        ShawnessyTowneCentre.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Signal Hill":
                        SignalHill.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "South Trail Crossing":
                        SouthTrailCrossing.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "Southcentre Mall":
                        SouthcentreMall.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    case "West Hills":
                        Westhills.GetComponent<SpriteRenderer>().sprite = GreenPin;
                        break;
                    default:
                        Debug.LogError("NO SITE OF NAME: " + siteNameString);
                        break;
                }
            }
        }
        else //the schedule is NULL
        {
            //set all pins to ORANGE
            CranstonMarket.GetComponent<SpriteRenderer>().sprite = OrangePin;
            DeerValley.GetComponent<SpriteRenderer>().sprite = OrangePin;
            DeerfootMeadows1.GetComponent<SpriteRenderer>().sprite = OrangePin;
            DeerfootMeadows2.GetComponent<SpriteRenderer>().sprite = OrangePin;
            HeritageMeadows.GetComponent<SpriteRenderer>().sprite = OrangePin;
            McKenzie.GetComponent<SpriteRenderer>().sprite = OrangePin;
            MillrisePlaza.GetComponent<SpriteRenderer>().sprite = OrangePin;
            RichmondRoad.GetComponent<SpriteRenderer>().sprite = OrangePin;
            Riverbend.GetComponent<SpriteRenderer>().sprite = OrangePin;
            Seton.GetComponent<SpriteRenderer>().sprite = OrangePin;
            ShawnessyGasBar.GetComponent<SpriteRenderer>().sprite = OrangePin;
            ShawnessyTowneCentre.GetComponent<SpriteRenderer>().sprite = OrangePin;
            SignalHill.GetComponent<SpriteRenderer>().sprite = OrangePin;
            SouthTrailCrossing.GetComponent<SpriteRenderer>().sprite = OrangePin;
            SouthcentreMall.GetComponent<SpriteRenderer>().sprite = OrangePin;
            Westhills.GetComponent<SpriteRenderer>().sprite = OrangePin;

            //Remove data from detail views
            SiteNameObject.GetComponent<TextMesh>().text = "NO SITE SELECTED";
            OperatorTextObject.GetComponent<TextMesh>().text = "NO OPERATOR SELECTED";
            DateObject.GetComponent<TextMesh>().text = selectedDate.Month + " " + selectedDate.Day;
        }
    }
}
