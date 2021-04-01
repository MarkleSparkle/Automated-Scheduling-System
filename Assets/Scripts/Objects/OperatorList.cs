using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * A list of Operators (SiteOperators)
 */
public class OperatorList
{

    private List<Operator> operatorList;

    public OperatorList()
    {
        generateOperatorList();
    }

    /**
     * Generates the Operator List from the hard coded values
     */
    private void generateOperatorList()
    {
        operatorList = new List<Operator>()
        {
            new Operator("Jesse Horne",Category.Priority, new Availability(true, true, false, true, true, true, true, "Jesse is unavailable every OTHER Thursday")),
            new Operator("Cooper Johnson", Category.Priority, new Availability(true, false, true, true, false, true, true)),
            new Operator("Mark Frezell",Category.Priority, new Availability(false, true, true, true, true, true, false)),
            new Operator("Emily Frezell",Category.High, new Availability(false, false, true, true, true, true, true)),
            new Operator("Brad Borkristl",Category.High, new Availability(true, true, true, false, true, true, false)),
            new Operator("William Kanuka",Category.High, new Availability(true, true, true, true, false, false, true)),
            new Operator("David Walker",Category.Medium, new Availability(true, false, true, true, true, true, false)),
            new Operator("Connor Schumacher",Category.High, new Availability(false, true, true, true, false, true, true)),
            new Operator("Niels Hendriks",Category.High, new Availability(true, true, false, false, false, true, true)),
            new Operator("Angelo Pastega",Category.High, new Availability(false, true, false, true, true, true, true)),
            new Operator("Nathan Sawatzky",Category.Low, new Availability(true, true, false, false, true, true, true)),
            new Operator("Dawson Kordikowski",Category.Low, new Availability(false, true, true, false, true, true, true)),
            new Operator("Cody David",Category.High, new Availability(true, true, true, true, true, false, true)),
        };
    }

    /**
     * Adds an Operator to the end of the List
     */
    public void addOperator(Operator newOperator)
    {
        operatorList.Add(newOperator);
    }

    /**
     * Gets the Operation of the same name and removes it from the List<Operator>
     */
    public Operator pullOperator(string name)
    {
        Operator siteOperator = getOperator(name);

        if (siteOperator != null)//if the Operator of name is in the List
        {
            removeOperator(name);//remove the operator
        }

        return siteOperator;

    }

    /**
     * Returns the Operator matching a name if the Operator is found in the List
     */
    private Operator getOperator(string name)
    {
        for (int i = 0; i < operatorList.Count; i++)
        {
            //if the name of the site is equal with the name input
            if (operatorList[i].getName().Equals(name))
            {
                return operatorList[i];
            }
        }
        return null;
    }

    /**
     * Removes an Operator from the list with a matching name value
     * If there is no match, nothing is removed
     * (used for scheduling)
     */
    private void removeOperator(string name)
    {
        for (int i = 0; i < operatorList.Count; i++)
        {
            //if the name of the site is equal with the name input
            if (operatorList[i].getName().Equals(name))
            {
                //removing the Operator at i from the OperatorList
                operatorList.Remove(operatorList[i]);
            }
        }

    }

    /* List Generating for Scheduler */

    /**
     * Generates List of a certain priority level personnel for the scheduler to compare with open sites 
     */
    private List<Operator> getOperatorsByCategory(Category categoryType)
    {
        List<Operator> categoryOperators = new List<Operator>();

        for (int i = 0; i < operatorList.Count; i++)
        {
            //if the Category of the Operator is High
            if (operatorList[i].getCategory() == categoryType)
            {
                //add the Operator to the High Priority List
                categoryOperators.Add(operatorList[i]);
            }
        }

        return categoryOperators;
    }

    /**
     * Returns all the Operators that are left in the list (for seeing who is unavailable)
     */
    public List<Operator> getRemainingOperators()
    {
        List<Operator> remaining = new List<Operator>();

        foreach(Operator op in operatorList)
        {
            remaining.Add(op);
        }

        return remaining;
    }

    /**
     * Pulls a random operator of a certain category
     * by generating a random number between 0 and size of category list
     * 
     * If there is no operators of a certain category returns null
     */
    public Operator pullRandomOperatorOf(Category category)
    {
        List<Operator> operatorsByCat = getOperatorsByCategory(category);
        int size = operatorsByCat.Count;

        if (size > 0) {
            //creating random number between 0 and size
            int randomNumber = new System.Random().Next(0, size);
            //pulls the operator of a random index
            return pullOperator(operatorsByCat[randomNumber].getName());
        }
        else
            return null;
    }

    /**
     * Operator list to string
     */
    public string toString()
    {
        string message = "Updated Site List ("+operatorList.Count+")\n";

        for(int i=0; i<operatorList.Count; i++)
        {
            message += operatorList[i].getName() + " of " + operatorList[i].getCategory()+" || ";
        }

        return message;
    }
}
