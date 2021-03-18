using System;

/**
 * Defines the states and behaviours of the Operator Object
 * Represents a Deco Site Operator
 */
public class Operator
{
    private string name;
    private Category category;
    private Availability availability;

    public Operator(string name, Category category, Availability availability)
    {
        this.name = name;
        this.category = category;
        this.availability = availability;
    }

    /* Name GET */
    public string getName()
    {
        return name;
    }

    /* Category SET/GET */
    public void setCategory(Category category)
    {
        this.category = category;
    }
    public Category getCategory()
    {
        return category;
    }


    /* Availability SET/GET */
    public void setAvailability(Availability availability)
    {
        this.availability = availability;
    }
    public Availability getAvailability()
    {
        return availability;
    }

    /* Helper Methods */

    /**
    * returns true/false based on if the Operator has Availability set on the DayOfWeek specified
    */
    public bool isAvailable(DayOfWeek dayOfWeek)
    {
        bool isAvailable = false;

        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                if (availability.getAvailability(DayOfWeek.Monday) == true)
                    isAvailable = true;
                break;

            case DayOfWeek.Tuesday:
                if (availability.getAvailability(DayOfWeek.Tuesday) == true)
                    isAvailable = true;
                break;

            case DayOfWeek.Wednesday:
                if (availability.getAvailability(DayOfWeek.Wednesday) == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Thursday:
                if (availability.getAvailability(DayOfWeek.Thursday) == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Friday:
                if (availability.getAvailability(DayOfWeek.Friday) == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Saturday:
                if (availability.getAvailability(DayOfWeek.Saturday) == true)
                    isAvailable = true;
                break;
            case DayOfWeek.Sunday:
                if (availability.getAvailability(DayOfWeek.Sunday) == true)
                    isAvailable = true;
                break;
        }

        return isAvailable;
    }

}
