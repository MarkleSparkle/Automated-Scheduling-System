using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * Develops the schedule for a certain period of time by randomly selecting operators
 * Contains some special case and consitions based on site operator performance
 */
public class Scheduler : MonoBehaviour
{
    private SiteList siteList;
    private OperatorList operatorList;
    private Dictionary<Site, Operator> siteOperatorPair;
    private List<Operator> unavailableOperators;
    private DateTime date;

    public Scheduler(DateTime date)
    {
        //instantiating a new SiteList and OperatorList
        siteList = new SiteList();
        operatorList = new OperatorList();
        siteOperatorPair = new Dictionary<Site, Operator>();
        unavailableOperators = new List<Operator>();
        this.date = date;
    }

    /**
     * Returns a pair of Sites and Operators based on what is available (day of week)
     * ASSUMES SelectedDate is up to date and current in this class
     */
    private void createSchedulesForDay()
    {

        //TODO - incorporate SelectedDate with DayOfWeek and avail

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
        }

        Debug.Log(operatorList.toString());


        /* Starting Priority Matching */

        Site site = getNextSite();
        Operator op = getNextOperator();

        //while neither the site NOR the operator are null (meaning there are still sites and operators of this level.
        while(site != null && op != null)
        {
            pairSiteAndOperator(site,op);
        }
        //number of Sites OR Operators have run out

        if (op != null)//if there are still Operators
        {
            while (op != null)//until there are no more operators 
            {
                //add the remaining operators to the unavailable list
                unavailableOperators.Add(op);
                op = getNextOperator();
            }
        }
        else //if there are still Sites
        {
            //do nothing (they will show as empty by default
        }


        if(unavailableOperators.Count > 0)//if there are more than 0 unavailable Operators
        {
            //load all the extra operators into the "Available Operators" list in Unity display
        }

    }

    /**
     * Returns a RANDOM Site in an order of Category
     * IE, it will never return a Medium Site if there are still High Sites available
     */
    private Site getNextSite()
    {
        //gets Site of High Category
        Site site = siteList.pullRandomSiteOf(Category.High);
        if(site == null)
        {
            site = siteList.pullRandomSiteOf(Category.Medium);//pull a Medium Site
            if(site == null)//if no Medium Sites
            {
                site = siteList.pullRandomSiteOf(Category.Low);//pull Low Site
                if(site == null)//if no Low Sites
                {
                    return null;
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
        //gets Operator of High Category
        Operator op = operatorList.pullRandomOperatorOf(Category.High);
        if(op == null)
        {
            op = operatorList.pullRandomOperatorOf(Category.Medium);//pull a Medium Operator
            if(op == null)//if no Medium Operator
            {
                op = operatorList.pullRandomOperatorOf(Category.Low);//pull Low Operator
                if(op == null)//if no Low 
                {
                    return null;
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
        siteOperatorPair.Add(site, employee);

    }

     /**
      * Allows other classes to retrieve the Schedule generated from the Scheduler
      */
     public void generateSchedule()
    {
        updateSelectedDate();//update DateTime date for this class (to generate schedule for the current date selected)
        createSchedulesForDay();//creates siteOperatorPair for Schedule
        Schedule schedule = new Schedule(date, siteOperatorPair);
        ScheduleList.add(schedule);//add schedule to ScheduleList
    }

    /**
     * Updates the Selected Date for this class (for when generation happens)
     */
    private void updateSelectedDate()
    {
        this.date = SelectedDate.getSelectedDate();
    }

    
}
