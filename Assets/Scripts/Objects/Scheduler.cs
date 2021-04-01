using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

/**
 * Develops the schedule for a certain period of time by randomly selecting operators
 * Contains some special case and consitions based on site operator performance
 */
public class Scheduler : MonoBehaviour
{
    private SiteList siteList;
    private OperatorList operatorList;
    private Dictionary<Site, Operator> siteOperatorPair;
    private List<Operator> availableOperators = new List<Operator>();
    private List<Operator> unavailableOperators = new List<Operator>();
    private DateTime date;




    /**
     * Returns a pair of Sites and Operators based on what is available (day of week)
     * ASSUMES SelectedDate is up to date and current in this class
     */
    private void createSchedulesForDay()
    {
        //date is up to date with SelectedDate

        //Instantiating new Operator and Site Lists
        operatorList = new OperatorList();
        siteList = new SiteList();
        siteOperatorPair = new Dictionary<Site, Operator>();

        /* Starts with Jesse Horne's Avaiability */
        Site richmondRoad = siteList.pullSite("Richmond Road");
        Operator jesseHorne = operatorList.pullOperator("Jesse Horne");
        if (jesseHorne.isAvailable(date.DayOfWeek)) //if available, match to Richmond Road Site
        {
            //gives Jesse Richmond Road right away
            pairSiteAndOperator(richmondRoad, jesseHorne);
        }
        else //if Jesse is NOT available on a certain day, Richmond Road is left on the table
        {
            unavailableOperators.Add(jesseHorne);
            siteList.addSite(richmondRoad);//adding Richmond Road back into the list (for grabs)
        }

        Debug.Log(operatorList.toString());


        /* Starting Priority Matching */

        Site site = getNextSite();
        Operator op = getNextOperator();

        //while neither the site NOR the operator are null (meaning there are still sites and operators of this level.
        while(site != null && op != null)
        {
            pairSiteAndOperator(site,op);
            site = getNextSite();
            op = getNextOperator();
            //get the next site and operator
        }
        //number of Sites OR Operators have run out

        if (op != null)//if there are still Operators
        {
            while (op != null)//until there are no more operators 
            {
                //add the remaining operators to their respected lists
                if (op.isAvailable(date.DayOfWeek))
                    availableOperators.Add(op);
                else
                    unavailableOperators.Add(op);

                op = getNextOperator();
            }
        }
        else //if there are still Sites
        {
            //do nothing (they will show as empty [orange] by default)
        }

        Debug.Log(operatorList.getRemainingOperators().Count + " remaining operators after generation.");

        //Debug Loop
        string msg = "Unavailable Operators -> ";
        foreach(Operator oper in unavailableOperators)
        {
            msg += unavailableOperators[0].getName()+", ";
        }
        Debug.Log(msg);
        //End Debug Loop


    }

    /**
     * Returns a RANDOM Site in an order of Category
     * IE, it will never return a Medium Site if there are still High Sites available
     */
    private Site getNextSite()
    {
        //gets Site of Priority Category
        Site site = siteList.pullRandomSiteOf(Category.Priority);
        if (site == null)
        {
            site = siteList.pullRandomSiteOf(Category.High);
            if (site == null)
            {
                site = siteList.pullRandomSiteOf(Category.Medium);//pull a Medium Site
                if (site == null)//if no Medium Sites
                {
                    site = siteList.pullRandomSiteOf(Category.Low);//pull Low Site
                    if (site == null)//if no Low Sites
                    {
                        return null;
                    }
                }
            }
        }
        return site;//returns the Site that is found
    }

    /**
     * Returns a RANDOM Operator in an order of Category
     * IE, it will never return a Medium Operator if there are still High Operators available
     */
    private Operator getNextOperator()
    {
        //gets Operator of Priority Category

        Operator op = operatorList.pullRandomOperatorOf(Category.Priority);
        if (op == null)
        {
            op = operatorList.pullRandomOperatorOf(Category.High);
            if (op == null)
            {
                op = operatorList.pullRandomOperatorOf(Category.Medium);//pull a Medium Operator
                if (op == null)//if no Medium Operator
                {
                    op = operatorList.pullRandomOperatorOf(Category.Low);//pull Low Operator
                    if (op == null)//if no Low 
                    {
                        return null;
                    }
                }
            }
        }
        return op;
    }

    /**
     * Once a pair is matched they are added to the dictionary for the <Site, Operator> match
     * the Site AND the Operator are then removed from the lists
     */
    private void pairSiteAndOperator(Site site, Operator employee)
    {
        Debug.Log("Pairing "+site.getName()+" to "+employee.getName());
        siteOperatorPair.Add(site, employee);

    }

     /**
      * Allows other classes to retrieve the Schedule generated from the Scheduler
      */
     public void generateSchedule()
    {
        updateSelectedDate();//update DateTime date for this class (to generate schedule for the current date selected)
        Debug.Log("Beginning scheduling for " + date.DayOfWeek + ", " + date.Month + "/" + date.Day + "/" + date.Year + ".");
        createSchedulesForDay();//creates siteOperatorPair for Schedule
        Schedule schedule = new Schedule(date, siteOperatorPair, availableOperators, unavailableOperators);
        ScheduleList.add(schedule);//add schedule to ScheduleList
    }

    /**
     * Updates the Selected Date for this class (for when generation happens)
     */
    private void updateSelectedDate()
    {
        this.date = SelectedDate.getSelectedDate();
    }

    /**
     * DANGER-ZONE
     * This method (theoretically) generates an entire month at a time
     * It saves the SelectedDate for later and iterates through the entire month
     */
     public void generateAll()
    {
        //saves the SelectedDate for when the generation is complete
        DateTime previousSelectedDate = SelectedDate.getSelectedDate();

        //initalizing the a DateTime at first day of the month
        int currentDay = 1;
        DateTime currentDate = new DateTime(previousSelectedDate.Year, previousSelectedDate.Month, currentDay);//first day of month

        //while (current date is less than or equal to number of days in month)
        while (currentDay <= DateTime.DaysInMonth(currentDate.Year, currentDate.Month))
        {
            SelectedDate.setSelectedDate(currentDate);//setting SelectedDate
            //if there is no schedule for this specific day
            if (ScheduleList.getScheduleFrom(currentDate) == null)
            {
                //generate a schedule for that day
                generateSchedule();
            }

            //iterate to next day
            currentDay++;
            if (currentDay <= DateTime.DaysInMonth(currentDate.Year, currentDate.Month))
            {
                currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDay);
            }
        }

        //once all days are developed, set date back to previousSelectedDate
        SelectedDate.setSelectedDate(previousSelectedDate);

    }
}
