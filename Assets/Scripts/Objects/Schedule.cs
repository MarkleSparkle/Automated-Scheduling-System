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

    /**
     * Creates and empty Schedule for a certain Date
     */
    public Schedule(DateTime associatedDate)
        {
            this.schedule = new Dictionary<Site, Operator>();
            this.associatedDate = associatedDate;
        }

    /**
     * Creates a deep copy of a pre-filled Schedule for a certain Date
     */
     public Schedule(DateTime associatedDate, Dictionary<Site,Operator> pairs)
    {
        this.schedule = pairs;
        this.associatedDate = associatedDate;
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

    /**
     * Returns the Site/Operator pairs in the form of a Dictionary
     */
    public Dictionary<Site, Operator> getPairs()
    {
        return schedule;
    }
}
