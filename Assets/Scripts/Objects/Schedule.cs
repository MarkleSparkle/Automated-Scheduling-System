using System;
using System.Collections.Generic;
using UnityEngine;

/**
 * Schedule SAVES the schedule data for a certain DATE 
 */
public class Schedule
{
    Dictionary<Site, Operator> schedule;
    DateTime associatedDate;
    private List<Operator> availableOperators = new List<Operator>();
    private List<Operator> unavailableOperators = new List<Operator>();

    /**
    * Creates a deep copy of a pre-filled Schedule for a certain Date
    */
    public Schedule(DateTime associatedDate, Dictionary<Site, Operator> pairs, List<Operator> available, List<Operator> unavailable)
    {
        this.schedule = pairs;
        this.associatedDate = associatedDate;
        this.availableOperators = available;
        this.unavailableOperators = unavailable;
    }

    /**
     * Gets the Date associated with the Schedule
     */
    public DateTime getDate()
    {
        return associatedDate;
    }

    public void setDate(DateTime associatedDate)
    {
        this.associatedDate = associatedDate;
    }

    public Operator getOpinSite(string name)
    {
        Dictionary<Site, Operator>.KeyCollection keys = schedule.Keys;//getting all the keys in the Dictionary
        foreach(Site key in keys)//for each of the sites
        {
            if (key.getName().Equals(name)){//does it have the same name
                //if so, return the operator of that site
                return schedule[key];
            }
        }

        return null;
    }

    /**
     * Returns the Site/Operator pairs in the form of a Dictionary
     */
    public Dictionary<Site, Operator> getPairs()
    {
        return schedule;
    }

    public List<Operator> getAvailableOperators()
    {
        return availableOperators;
    }

    public List<Operator> getUnavailableOperators()
    {
        return unavailableOperators;
    }
}
