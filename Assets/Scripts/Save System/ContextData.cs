using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * The ContextData class is a serializable class that describes the data needed to 
 * provide the "last viewed" context data when the user shut down the program.
 * 
 * Context Data includes
 * - Last Selected Date
 * - Site Selected
 */
 [System.Serializable]
public class ContextData
{
    int lastSelectedSiteID;//the ID of the "selected" site (blue pin)
    int[] lastSelectedDate;//[year,month,day]

    ContextData(DateTime selectedDate, int selectedSiteId)
    {
        lastSelectedSiteID = selectedSiteId;

        lastSelectedDate[0] = selectedDate.Year;
        lastSelectedDate[1] = selectedDate.Month;
        lastSelectedDate[2] = selectedDate.Day;

    }
}
