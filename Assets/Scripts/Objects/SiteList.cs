using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteList
{
    private List<Site> siteList;

    public SiteList()
    {
        generateSiteList();
    }

    /**
     * Generates a Queue from the list based on priority 
     */
    private void generateSiteList()
    {
        siteList = new List<Site>
        {
            new Site("Cranston Market",Category.Medium), new Site("Deer Valley",Category.Medium),
            new Site("Deerfoot Meadows I",Category.Low), new Site("Deerfood Meadows 2",Category.Low),
            new Site("Heritage Meadows",Category.High), new Site("McKenzie",Category.High),
            new Site("Millrise Plaza",Category.Medium), new Site("Richmond Road",Category.High),
            new Site("Riverbend",Category.Medium), new Site("Seton",Category.Low),
            new Site("Shawnessy Gas Bar",Category.High), new Site("Shawnessy Towne Centre",Category.High),
            new Site("Signal Hill",Category.High), new Site("South Trail Crossing",Category.Medium),
            new Site("Southcentre Mall",Category.Medium), new Site("Southland Macleod",Category.Medium),
            new Site("West Hills",Category.High)//17 sites
        };
    }

    /**
     * Returns the size of the SiteList
     */
     public int size()
    {
        return siteList.Count;
    }

    /**
     * Gets the site infromation and removes it from the list
     */
    public Site pullSite(string name)
    {
        Site site = getSite(name);//get the Site

        if (site != null)//if the Site is in the List
        {
            removeSite(name);//remove it
        }
        return site;
        //returns the Site or null
    }
    /**
     * Returns a site of a certain index from the overloaded pullSite (string name) method
     */
    private Site pullSite(int i)
    {
        return pullSite(siteList[i].getName());
    }

    /**
     * Returns the Site that makes the name input
     * If not Site matches, returns null
     */
    private Site getSite(string name)
    {
        for(int i=0; i<siteList.Count; i++)
        {
            //if the name of the site is equal with the name input
            if (siteList[i].getName().Equals(name))
            {
                return siteList[i];
            }
        }
        return null;
    }

    /**
     * Removes the Site from the List
     * (used when scheduling)
     */
    private void removeSite(string name)
    {
        for (int i = 0; i < siteList.Count; i++)
        {
            //if the name of the site is equal with the name input
            if (siteList[i].getName().Equals(name))
            {
                siteList.Remove(siteList[i]);
            }
        }
        
    }

    private List<Site> getSitesByCategory(Category categoryType)
    {
        List<Site> categorySites = new List<Site>();

        for (int i = 0; i < siteList.Count; i++)
        {
            //if the Category of the Operator is High
            if (siteList[i].getCategory() == categoryType)
            {
                //add the Operator to the High Priority List
                categorySites.Add(siteList[i]);
            }
        }

        return categorySites;
    }

    /**
     * Pulls a random Site of a certain category
     * by generating a random number between 0 and size of category list
     * 
     * If there is no Sites of a certain category returns null
     */
    public Site pullRandomSiteOf(Category category)
    {
        List<Site> sitesByCat = getSitesByCategory(category);
        int size = sitesByCat.Count;

        if (size > 0)
        {
            //creating random number between 0 and size
            int randomNumber = new System.Random().Next(0, size);
            Debug.Log("Random Number: " + randomNumber);
            //pulls the operator of a random index
            return pullSite(randomNumber);
        }
        else
            return null;
    }

    public string toString()
    {
        string message = "Updated Site List\n";

        for (int i = 0; i < siteList.Count; i++)
        {
            message += "" + siteList[i].getName() + " " + siteList[i].getCategory() + "\n";
        }

        return message;
    }
}
