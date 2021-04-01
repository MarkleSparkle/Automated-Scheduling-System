using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FROM BRACKEYS - https://www.youtube.com/watch?v=XOjd_qU2Ido

/**
 * The Schedule Data class is a serializable class that describes all the generated schedule data
 * 
 * The Schedule Data includes
 * - Array of Schedules
 *      - Schedules are broken down to pairs(2d arrays) of Site IDs and Operator IDs
 * - Dates associated with each Schedule
 *      - Broken down as arrays from DateTime [year,month,day] 
 */
[System.Serializable]
public class ScheduleData
{
    //TODO - create variables that would contain the data of the software

    public ScheduleData(List<Schedule> scheduleList)
    {
        //call method to define serializable variables from the schedule
    }

    //TODO - create a serialization function here for a Schedule


}
