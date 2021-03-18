using System;

public class Availability
{
    bool[] availability;
    string specialNotes;

    /**
     * Instantiating Availability
     */
    public Availability(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
    {
        //instantiating an array with the values input
        availability = new bool[] {monday, tuesday, wednesday, thursday, friday, saturday, sunday};
    }

    /**
     * Instantiating Availability with SPECIAL NOTES
     */
    public Availability(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday, string specialNotes)
    {
        //instantiating an array with the values input
        availability = new bool[] { monday, tuesday, wednesday, thursday, friday, saturday, sunday };
        this.specialNotes = specialNotes;
    }

    /* Availability GET/SET */
    public void setAvailability(bool monday, bool tuesday, bool wednesday, bool thursday, bool friday, bool saturday, bool sunday)
    {
        availability = new bool[] { monday, tuesday, wednesday, thursday, friday, saturday, sunday};
    }

    public bool getAvailability(DayOfWeek dayOfWeek)
    {
        bool isAvailable = false;

        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                if (availability[0] == true)
                    isAvailable = true;
                break;

            case DayOfWeek.Tuesday:
                if (availability[1] == true)
                    isAvailable = true;
                break;

            case DayOfWeek.Wednesday:
                if (availability[2] == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Thursday:
                if (availability[3] == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Friday:
                if (availability[4] == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Saturday:
                if (availability[5] == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Sunday:
                if (availability[6] == true)
                    isAvailable = true;
                break;
        }

        return isAvailable;
    }

    /* Special Notes GET/SET */
    public void setSpecialNotes(string specialNotes)
    {
        this.specialNotes = specialNotes;
    }
    public string getSpecialNotes()
    {
        return specialNotes;
    }

}
