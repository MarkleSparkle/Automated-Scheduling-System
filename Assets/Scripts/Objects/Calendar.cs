using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public GameObject buttonGroup;
    public ScheduleList scheduleList;

    // Start is called before the first frame update
    void Start()
    {
        populateCalendar();
    }

    /**
     * Populate Calendar populates the calendar based on the selectedDate
     */
    private void populateCalendar()
    {
        //gets the DayOfWeek of first day of month, of the month that is selected
        DateTime selectedDate = SelectedDate.getSelectedDate();
        DayOfWeek firstDayOfMonth = getFirstDayOfMonth(selectedDate);

        /* Iterating through the children of the first row to set the first date */

        //getting the first row in the button group
        Transform row1 = buttonGroup.transform.Find("Row 1");

        //getting each child into a list of <Transform> from the first row of buttons (group)
        List<Transform> buttons = getChildListFromTransform(row1);

        int firstButtonIndex = 0;
        //set a "1" on the day of the week that cooralates with that day in the first 
        //Sunday is the first day of the week (in button list)
        switch (firstDayOfMonth)
        {
            case DayOfWeek.Sunday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[0].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn0 = new GameObject();
                newBtn0 = buttons[0].gameObject;
                buttons[0].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn0));
                firstButtonIndex = 0;
                break;

            case DayOfWeek.Monday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[1].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn1 = new GameObject();
                newBtn1 = buttons[1].gameObject;
                buttons[1].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn1));
                firstButtonIndex = 1;
                break;

            case DayOfWeek.Tuesday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[2].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn2 = new GameObject();
                newBtn2 = buttons[2].gameObject;
                buttons[2].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn2));
                firstButtonIndex = 2;
                break;

            case DayOfWeek.Wednesday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[3].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn3 = new GameObject();
                newBtn3 = buttons[3].gameObject;
                buttons[3].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn3));
                firstButtonIndex = 3;
                break;

            case DayOfWeek.Thursday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[4].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn4 = new GameObject();
                newBtn4 = buttons[4].gameObject;
                buttons[4].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn4));
                firstButtonIndex = 4;
                break;

            case DayOfWeek.Friday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[5].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn5 = new GameObject();
                newBtn5 = buttons[5].gameObject;
                buttons[5].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn5));
                firstButtonIndex = 5;
                break;

            case DayOfWeek.Saturday:
                //finding the child of the button (TMP), accessing the gameobject (of the transform), getting the TextMesh, then changing the text
                buttons[6].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "1";
                //setting the button on click
                GameObject newBtn6 = new GameObject();
                newBtn6 = buttons[6].gameObject;
                buttons[6].gameObject.GetComponent<Button>().onClick.AddListener(() => buttonWithDateOnClick(newBtn6));
                firstButtonIndex = 6;
                break;
        }
        //GOT FOREACH FROM https://answers.unity.com/questions/594210/get-all-children-gameobjects.html

        int nextNumber = 2;
        //setting the rest of the first row to the correct numbers
        for (int nextButtonIndex = firstButtonIndex + 1; nextButtonIndex < 7; nextButtonIndex++)
        {
            //making a local variable to avoid this //https://answers.unity.com/questions/912202/buttononclicaddlistenermethodobject-wrong-object-s.html
            int newInt = new int();
            newInt = nextButtonIndex;
            //set the next button to the next number
            buttons[nextButtonIndex].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "" + nextNumber;
            //adding button on click

            GameObject newBtn = new GameObject();//instantiating a new GameObject for the button to live in
            newBtn = buttons[newInt].gameObject;//this way it doesn't return the last item

            buttons[nextButtonIndex].gameObject.GetComponent<Button>().onClick.AddListener(() =>
                 buttonWithDateOnClick(newBtn));

            nextNumber++;
        }


        //populates the buttons BEFORE first button index

        //the last set starts from the last day from the previous month
        int lastDaySet = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month - 1);

        //loops through the days BEFORE the first day of the month
        for (int i = firstButtonIndex-1; i>=0; i--)
        {
            //making a local variable to avoid this //https://answers.unity.com/questions/912202/buttononclicaddlistenermethodobject-wrong-object-s.html
            int newInt = new int();
            newInt = i;
            //set the next button to the next number
            buttons[i].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "" + lastDaySet;
            //adding button on click

            GameObject newBtn = new GameObject();//instantiating a new GameObject for the button to live in
            newBtn = buttons[newInt].gameObject;//this way it doesn't return the last item

            newBtn.gameObject.GetComponent<Button>().onClick.AddListener(() =>
                 prevMonthButtonOnClick());

            lastDaySet--;
        }

        //now for row 2,3,4,and 5
        //while the next number does not exceed the number of days in the month
        int nextIndex = 0;
        int nextRow = 2;
        Transform row = buttonGroup.transform.Find("Row " + nextRow);
        buttons = getChildListFromTransform(row);
        while (nextNumber <= DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month))
        {
            if (nextIndex > 6)//if there no space left in the row (index is 7+)
            {
                nextIndex = 0;
                //next row
                nextRow++;
                row = buttonGroup.transform.Find("Row " + nextRow);
                buttons = getChildListFromTransform(row);
                //we will never get a row that doesn't exist because we'll run out of days (nextNumber) first
            }

            buttons[nextIndex].Find("Text (TMP)").gameObject.GetComponent<TMP_Text>().text = "" + nextNumber;

            GameObject newBtn = new GameObject();//instantiating a new GameObject for the button to live in
            newBtn = buttons[nextIndex].gameObject;//this way it doesn't return the last item

            buttons[nextIndex].gameObject.GetComponent<Button>().onClick.AddListener(() =>
                 buttonWithDateOnClick(newBtn));

            nextNumber++;//nextDate
            nextIndex++;//next index
        }

        //TODO populate the buttons left in the last row
    }

    /**
     * Gets the DayOfWeek form the first day of the selected month
     */
    private DayOfWeek getFirstDayOfMonth(DateTime selectedDate)
    {
        DayOfWeek firstDayOfMonth = DayOfWeek.Sunday;
        switch (new DateTime(selectedDate.Year, selectedDate.Month, 1).DayOfWeek)
        {
            case DayOfWeek.Monday:
                firstDayOfMonth = DayOfWeek.Monday;
                break;

            case DayOfWeek.Tuesday:
                firstDayOfMonth = DayOfWeek.Tuesday;
                break;

            case DayOfWeek.Wednesday:
                firstDayOfMonth = DayOfWeek.Wednesday;
                break;

            case DayOfWeek.Thursday:
                firstDayOfMonth = DayOfWeek.Thursday;
                break;

            case DayOfWeek.Friday:
                firstDayOfMonth = DayOfWeek.Friday;
                break;

            case DayOfWeek.Saturday:
                firstDayOfMonth = DayOfWeek.Saturday;
                break;

            case DayOfWeek.Sunday:
                firstDayOfMonth = DayOfWeek.Sunday;
                break;
            default:
                firstDayOfMonth = DayOfWeek.Sunday;
                break;
        }
        return firstDayOfMonth;
    }

    /**
     * Changes an IEmuerate from transform into a List<Transform>
     */
    private List<Transform> getChildListFromTransform(Transform row)
    {
        List<Transform> buttons = new List<Transform>();
        foreach (Transform child in row)
        {
            buttons.Add(child);
        }
        return buttons;
    }


    /**
     * This is the on click that is assigned (programmatically)
     * to each button in the row that represent a date of the month
     * 
     * The method sets the selected date and changes the color of the button
     */
    private void buttonWithDateOnClick(GameObject buttonGameObject)
    {
        Button button = buttonGameObject.GetComponent<Button>();
        GameObject parent = button.transform.parent.gameObject;//the parent GameObject of the button

        //getting TMP_Text child of button
        TMP_Text buttonText = button.transform.Find("Text (TMP)").GetComponent<TMP_Text>();

        Debug.Log(""+parent.name);//the row name
        Debug.Log("Button Clicked:'"+ buttonText.text +"'");

        //sets SelectedDate to the number of the month that is labeled on the button

        DateTime selectedDate = SelectedDate.getSelectedDate();
        Debug.Log("Setting the SelectedDate to Year:" + selectedDate.Year + " Month:" + selectedDate.Month + " Day:" + int.Parse(buttonText.text));
        SelectedDate.setSelectedDate(new DateTime(selectedDate.Year, selectedDate.Month, int.Parse(buttonText.text)));

        //setting the button (based on SelectedDate) to the same light blue color as the BluePin
        setSelectedButton();
        scheduleList.populateMap();
    }

    /**
     * Sets the button (and only one button) to the selected color (light blue)
     * based on the SelectedDate
     * 
     * used when date is changed from the map as well
     */
    public void setSelectedButton()
    {

        DateTime selectedDate = SelectedDate.getSelectedDate();
        List<Transform> buttons = new List<Transform>();

        //finding what row and column the SelectedDate would be
        int rowIndex = 1;//rows 1-5
        int colIndex = 0;//col 0-6

        //day of week of the first day of the month
        DayOfWeek firstDayOfWeek = new DateTime(selectedDate.Year,selectedDate.Month,1).DayOfWeek;

        //get daysInFirstWeek
        int daysInFirstWeek = 0;
        switch (firstDayOfWeek)
        {
            case DayOfWeek.Sunday:
                daysInFirstWeek = 7;//seven days if the month starts on Sunday
                break;
            case DayOfWeek.Monday:
                daysInFirstWeek = 6;
                break;
            case DayOfWeek.Tuesday:
                daysInFirstWeek = 5;
                break;
            case DayOfWeek.Wednesday:
                daysInFirstWeek = 4;
                break;
            case DayOfWeek.Thursday:
                daysInFirstWeek = 3;
                break;
            case DayOfWeek.Friday:
                daysInFirstWeek = 2;
                break;
            case DayOfWeek.Saturday:
                daysInFirstWeek = 1;//Saturday is the only day of the week in the first row
                break;
        }

        //if (selectedDate.Day is <= daysInFirstWeek) then rowIndex = 1
        if (selectedDate.Day <= daysInFirstWeek)
        {
            rowIndex = 1;
        }
        //else rowIndex = selectedDate.Day-daysInFirstWeek/(daysInMonth/4) [cause 4 rows left]
        else
        {
            //previous algorithm Math.Floor(((selectedDate.Day - daysInFirstWeek)) / (DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month) / 4.0f)))

            //formula  a combination of custom and from https://www.youtube.com/watch?v=Xwd-O2Iowag
            Debug.Log("rowIndex (non-round):" + ((selectedDate.Day - daysInFirstWeek) / 7.0f));
            rowIndex = (int) Math.Floor(((selectedDate.Day - daysInFirstWeek) / 7.0f)-0.1f);
            rowIndex = rowIndex+2;
            Debug.Log("rowIndex:"+rowIndex);
        }

        //finds the colIndex
        DayOfWeek dayOfWeek = selectedDate.DayOfWeek;
        switch (dayOfWeek)
        {
            case DayOfWeek.Sunday:
                colIndex = 0;
                break;
            case DayOfWeek.Monday:
                colIndex = 1;
                break;
            case DayOfWeek.Tuesday:
                colIndex = 2;
                break;
            case DayOfWeek.Wednesday:
                colIndex = 3;
                break;
            case DayOfWeek.Thursday:
                colIndex = 4;
                break;
            case DayOfWeek.Friday:
                colIndex = 5;
                break;
            case DayOfWeek.Saturday:
                colIndex = 6;
                break;
        }

        Debug.Log("SelectedDate is located at row:"+rowIndex+" col:"+colIndex);

        Transform row;
        //iterating through rows
        for (int i = 1; i < 6; i++) {
            row = buttonGroup.transform.Find("Row " + i);
            buttons = getChildListFromTransform(row);

            //iterating through buttons in the row
            for (int j = 0; j < 7; j++)
            {
                //set all buttons back to original color
                buttons[j].gameObject.GetComponent<Image>().color = new Color(1,1,1);
                
                //if the selected date is at this index
                if (rowIndex == i && colIndex == j)
                {
                    //change to the selected color
                    buttons[j].GetComponent<Image>().color = new Color(117f / 255f, 136f / 255f, 233f / 255f);
                }
            }
        }
    }

    /**
     * This is the on click that is assigned programmatically
     * to the buttons that represent values from a previous month
     * 
     * The method sets the calendar value to represent the previous month
     */
    private void prevMonthButtonOnClick()
    {
        //setting SelectedDate to last day of the previous month
        DateTime currentDate = SelectedDate.getSelectedDate();
        SelectedDate.setSelectedDate(new DateTime(currentDate.Year, currentDate.Month-1, DateTime.DaysInMonth(currentDate.Year, currentDate.Month-1)));
        
        //populate the calendar again
        populateCalendar();
        scheduleList.populateMap();
    }

    /**
     * This is the onclick that is assigned programmatically
     * to the buttons that represent values for the NEXT month
     * 
     * This method sets the calendar values to represent the next month 
     */
    private void nextMonthButtonOnClick()
    {
        //since the SelectedDate is already set, we can just populate the calendar again
        populateCalendar();
    }
}
