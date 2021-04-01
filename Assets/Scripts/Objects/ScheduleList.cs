using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScheduleList : MonoBehaviour 
{
    //Detail View Section
    public TMP_Text SiteNameObject;//Text - TextMeshPro
    public TMP_Text OperatorTextObject;
    public TMP_Text DateObject;

    //the content box for available/unavailable operators
    public GameObject availOpsContent;

    //Pins
    public Button CranstonMarket, DeerValley, DeerfootMeadows1, DeerfootMeadows2, HeritageMeadows, McKenzie, MillrisePlaza,
        RichmondRoad, Riverbend, Seton, ShawnessyGasBar, ShawnessyTowneCentre, SignalHill, SouthTrailCrossing, SouthcentreMall,
        SouthlandMacleod, WestHills;

    public Sprite OrangePin, GreenPin, BluePin;

    private static List<Schedule> scheduleList = new List<Schedule>();

    private List<Operator> availableOperators = new List<Operator>();
    private List<Operator> unavailableOperators = new List<Operator>();

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
    public static Schedule getScheduleFrom(DateTime date)
    {
        for(int i=0; i<scheduleList.Count; i++)
        {
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

        Debug.Log("Populating Map with "+selectedDate.Month+"/"+selectedDate.Day+"/"+selectedDate.Year+"'s schedule");

        //gets Schedule from scheduleList that matches the selectedDate
        Schedule schedule = getScheduleFrom(selectedDate);

        //reseting the color of all the pins
        setAllPinsOrange();

        if (schedule != null) {
            Dictionary<Site, Operator> siteOperatorPair = schedule.getPairs();//getting the Dictionary from the Schedule
            Dictionary<Site, Operator>.KeyCollection keys = siteOperatorPair.Keys;//getting all the keys in the Dictionary

            //changing all the Pins that have pairs (operators) to green pins
            foreach (Site key in keys)
            {//iterating through all of the keys in the Dictionary

                //getting all of the Sites and Operators to log
                string siteNameString = key.getName();//name of Site

                //if the string matches a Site name change its sprite to GreenPin
                switch (siteNameString)
                {
                    case "Cranston Market":
                        CranstonMarket.image.sprite = GreenPin;
                        break;
                    case "Deer Valley":
                        DeerValley.image.sprite = GreenPin;
                        break;
                    case "Deerfoot Meadows 1":
                        DeerfootMeadows1.image.sprite = GreenPin;
                        break;
                    case "Deerfoot Meadows 2":
                        DeerfootMeadows2.image.sprite = GreenPin;
                        break;
                    case "Heritage Meadows":
                        HeritageMeadows.image.sprite = GreenPin;
                        break;
                    case "McKenzie":
                        McKenzie.image.sprite = GreenPin;
                        break;
                    case "Millrise Plaza":
                        MillrisePlaza.image.sprite = GreenPin;
                        break;
                    case "Richmond Road":
                        RichmondRoad.image.sprite = GreenPin;
                        break;
                    case "Riverbend":
                        Riverbend.image.sprite = GreenPin;
                        break;
                    case "Seton":
                        Seton.image.sprite = GreenPin;
                        break;
                    case "Shawnessy Gas Bar":
                        ShawnessyGasBar.image.sprite = GreenPin;
                        break;
                    case "Shawnessy Towne Centre":
                        ShawnessyTowneCentre.image.sprite = GreenPin;
                        break;
                    case "Signal Hill":
                        SignalHill.image.sprite = GreenPin;
                        break;
                    case "South Trail Crossing":
                        SouthTrailCrossing.image.sprite = GreenPin;
                        break;
                    case "Southland Macleod":
                        SouthlandMacleod.image.sprite = GreenPin;
                        break;
                    case "Southcentre Mall":
                        SouthcentreMall.image.sprite = GreenPin;
                        break;
                    case "West Hills":
                        WestHills.image.sprite = GreenPin;
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
            setAllPinsOrange();
        }

        //setting the information for the Site Detail View
        Site selectedSite = SelectedSite.getSelectedSite();
        //Remove data from detail views

        if (schedule != null && selectedSite != null)//if there is a schedule and selected Site
        {
            //set selectedSite name
            SiteNameObject.text = "" + selectedSite.getName();
            
            //gets operator at site of name
            Operator op = schedule.getOpinSite(selectedSite.getName());
            if (op != null)//if an operator was found
                //set operator name
                OperatorTextObject.text = "Operator : " + op.getName();
            else
                OperatorTextObject.text = "Operator : NONE";
        }
        else if(selectedSite != null)//if there is date but no schedule
        {
            SiteNameObject.text = "" + selectedSite.getName();//set the selectedsite
            OperatorTextObject.text = "Operator : N/A";//no operator
        }
        else//no selectedSite or schedule
        {
            SiteNameObject.text = "No Site Selected";//no selectedSite
            OperatorTextObject.text = "Operator : N/A";
        }

        DateObject.text = selectedDate.ToString("ddd, MMM") + " " + selectedDate.Day;

        setBluePin();//sets the blue pin based on the SelectedSite
                     //this is done at the end so that it is not overwritten to green or orange

        updateAvailableOperators(schedule);
        displayAvailOperators();//Displays all the Available and Unavailable Operators

    }

    /**
     * Sets the blue pin into the selected location
     */
    private void setBluePin()
    {
        if (SelectedSite.getSelectedSite() != null)//if there is no selected site, don't add a blue pin
        {
            Site selectedSite = SelectedSite.getSelectedSite();

            //based on the selected Site's name, get the sprite to BluePin
            switch (selectedSite.getName())
            {
                case "Cranston Market":
                    CranstonMarket.image.sprite = BluePin;
                    break;
                case "Deer Valley":
                    DeerValley.image.sprite = BluePin;
                    break;
                case "Deerfoot Meadows 1":
                    DeerfootMeadows1.image.sprite = BluePin;
                    break;
                case "Deerfoot Meadows 2":
                    DeerfootMeadows2.image.sprite = BluePin;
                    break;
                case "Heritage Meadows":
                    HeritageMeadows.image.sprite = BluePin;
                    break;
                case "McKenzie":
                    McKenzie.image.sprite = BluePin;
                    break;
                case "Millrise Plaza":
                    MillrisePlaza.image.sprite = BluePin;
                    break;
                case "Richmond Road":
                    RichmondRoad.image.sprite = BluePin;
                    break;
                case "Riverbend":
                    Riverbend.image.sprite = BluePin;
                    break;
                case "Seton":
                    Seton.image.sprite = BluePin;
                    break;
                case "Shawnessy Gas Bar":
                    ShawnessyGasBar.image.sprite = BluePin;
                    break;
                case "Shawnessy Towne Centre":
                    ShawnessyTowneCentre.image.sprite = BluePin;
                    break;
                case "Signal Hill":
                    SignalHill.image.sprite = BluePin;
                    break;
                case "South Trail Crossing":
                    SouthTrailCrossing.image.sprite = BluePin;
                    break;
                case "Southland Macleod":
                    SouthlandMacleod.image.sprite = BluePin;
                    break;
                case "Southcentre Mall":
                    SouthcentreMall.image.sprite = BluePin;
                    break;
                case "West Hills":
                    WestHills.image.sprite = BluePin;
                    break;
                default:
                    Debug.LogError("NO SITE OF NAME: " + selectedSite.getName());
                    break;
            }
        }
    }

    /**
     * This method is when switching dates (reseting all of the pins to empty)
     * whether there is a schedule or not
     */
    private void setAllPinsOrange()
    {
        CranstonMarket.image.sprite = OrangePin;
        DeerValley.image.sprite = OrangePin;
        DeerfootMeadows1.image.sprite = OrangePin;
        DeerfootMeadows2.image.sprite = OrangePin;
        HeritageMeadows.image.sprite = OrangePin;
        McKenzie.image.sprite = OrangePin;
        MillrisePlaza.image.sprite = OrangePin;
        RichmondRoad.image.sprite = OrangePin;
        Riverbend.image.sprite = OrangePin;
        Seton.image.sprite = OrangePin;
        ShawnessyGasBar.image.sprite = OrangePin;
        ShawnessyTowneCentre.image.sprite = OrangePin;
        SignalHill.image.sprite = OrangePin;
        SouthTrailCrossing.image.sprite = OrangePin;
        SouthlandMacleod.image.sprite = OrangePin;
        SouthcentreMall.image.sprite = OrangePin;
        WestHills.image.sprite = OrangePin;
    }

    private void updateAvailableOperators(Schedule schedule)
    {
        //if there actually is a schedule
        if (schedule != null)
        {
            Debug.Log("<b>Updating Available Operators</b>");
            availableOperators = schedule.getAvailableOperators();
            unavailableOperators = schedule.getUnavailableOperators();
        }
        else
        { //if there is no schedule reset available/unavailable to null (as not to remain from a previous schedule)
            availableOperators = new List<Operator>();
            unavailableOperators = new List<Operator>();
        }
    }

    /**
     * Displays the names of the unavailable operators
     */
    private void displayAvailOperators()
    {
        //destroying any displayed operators here
        foreach (Transform child in availOpsContent.transform)
        {
            GameObject.Destroy(child.gameObject);
        }


        Debug.Log("Displaying Available Operators \\ Avail: " + availableOperators.Count + " \\ Unavail: " + unavailableOperators.Count + ".");

        //Add "Available Ops" Title
        addComponentWithText("Available Operators", true, availOpsContent);//add text with BOLD (title)

        //IF there are any available operators
        if (availableOperators.Count > 0)
        {
            //Loop through the remainder of the operators
            for (int i = 0; i < availableOperators.Count; i++)
            {
                addComponentWithText(availableOperators[i].getName(), false, availOpsContent);
            }
        }
        else
        {
            //Add "No Available Operators" Text
            addComponentWithText("No Available Operators", false, availOpsContent);
        }

        //Add "Unavailable Operators" Title
        addComponentWithText("Unavailable Operators", true, availOpsContent);//add text with BOLD (title)

        //IF there are any unavailable operators
        if (unavailableOperators.Count > 0)
        {
            //Loop through the remainder of the operators
            for (int i = 0; i < unavailableOperators.Count; i++)
            {
                addComponentWithText(unavailableOperators[i].getName(), false, availOpsContent);
            }
        }
        else
        {
            //Add "No Unavailable Operators" Text
            addComponentWithText("No Unavailable Operators", false, availOpsContent);
        }
    }

    public void addComponentWithText(string msg, bool title, GameObject parent)
    {
        GameObject availTitle = new GameObject();//creating a new GameObject
        Text text = availTitle.AddComponent<Text>();//adding a Text component
        text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");//arial font
        text.fontSize = 10;//setting the fontsize
        text.color = Color.black;//changing color
        text.verticalOverflow = VerticalWrapMode.Overflow;

        if (title)
            text.alignment = TextAnchor.MiddleCenter;//centered for titles
        else
            text.alignment = TextAnchor.MiddleLeft;//left justified for regular

        //adding bold for title & setting title
        if (title)
            text.text = "<b>" + msg + "</b>";//setting the text
        else
            text.text = "   " + msg;

        availTitle.GetComponent<RectTransform>().sizeDelta = new Vector2(150.35f, 18.45f);//setting the width and height of the Rect Transform

        availTitle.transform.SetParent(parent.transform);//adding the parent to availTitle
        availTitle.transform.position = new Vector3(transform.position.x, transform.position.y, 0);//change z to 0
        availTitle.transform.localScale = new Vector3(1, 1, 1);//scale to 1

        Debug.Log("Added " + text.text + " to " + parent.name + ".");
    }
}
