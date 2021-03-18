/**
 * Site object encapsulating the states and behaviours of Site 
 * Represents a site location
 */
public class Site
{

    private string name;
    private Category category;

    //site is NOT optimized by default
    private bool optimized = false;
    private Availability activeDays;//the days that the site is ACTIVE for
    private float optimizedStart = 0f;//the start time in 24hrs (1-24)
    private float optimizedEnd = 0f;//the end time in 24hrs (1-24)

    public Site(string name, Category category)
    {
        this.name = name;
        this.category = category;
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

    /* Optimization SET/GET */
    public void setOptimization(bool optimized, float optimizedStart, float optimizedEnd, Availability activeDays)
    {
        this.optimized = optimized;
        this.optimizedStart = optimizedStart;
        this.optimizedEnd = optimizedEnd;
        this.activeDays = activeDays;
    }
    public bool isOptimized()
    {
        return optimized;
    }
    public float getOptimizedStart()
    {
        return optimizedStart;
    }
    public float getOptimizedEnd()
    {
        return optimizedEnd;
    }
    public Availability getActiveDays()
    {
        return activeDays;
    }
}


