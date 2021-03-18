using System;
using UnityEngine;

//this is NOT an object because there is only ONE selected Date at a time
public class SelectedDate : MonoBehaviour
{
    private static DateTime selectedDate = new DateTime(2021, 6, 1);//year, month, day (June 1st)

    /**
     * Accessor method for selectedDate
     */
    public static DateTime getSelectedDate()
    {
        return selectedDate;
    }

    /**
     * Mutator method for selectedDate
     */
    public static void setSelectedDate(DateTime date)
    {
        selectedDate = date;
    }

    /**
     * Adds one to the date
     * If date is at the end of the month, iterate to next month
     * If date is end of year, iterate to next year
     */
    public void datePlusOne()
    {
        int day = selectedDate.Day;
        int month = selectedDate.Month;
        int year = selectedDate.Year;

        //if the CURRENT DAY is the LAST day of the month
        if(day == DateTime.DaysInMonth(year, month))
        {
            //if the CURRENT MONTH is the LAST month of the year
            if (selectedDate.Month == 12)
            {
                //new year
                year++;
                month = 1;
                day = 1;
            }
            else//not last month of year, but last day of month
            {
                //year is the same
                month++;
                day = 1;
            }
        }
        else // not last day of month
        {
            day++;
        }

        //new date is what is set above
        selectedDate = new DateTime(year, month, day);

    }

    /**
     * Subtracts one from the date
     * If first date of the month, got to previous month (last day)
     */
     public void dateMinusOne()
    {
        int day = selectedDate.Day;
        int month = selectedDate.Month;
        int year = selectedDate.Year;

        //if it is the first day of the month
        if (day == 1)
        {
            //if month is the first month of the year
            if(month == 1)
            {
                //go back one year (December, 31)
                year--;
                month = 12;
                day = 31;
            }
            else//if month is not first month, but day is start of month
            {
                month--;
                day = DateTime.DaysInMonth(year, month);//last day of the current year and NEW month
            }
        }
        else //not first day of the month
        {
            day--;
        }

        selectedDate = new DateTime(year, month, day);

    }

}
