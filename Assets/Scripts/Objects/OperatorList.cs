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
            new Operator("Jesse Horne",Category.High, new Availability(true, true, false, true, true, true, true, "Jesse is unavailable every OTHER Thursday")),
            new Operator("Cooper Johnson", Category.High, new Availability(true, false, true, true, false, true, true)),
            new Operator("Mark Frezell",Category.High, new Availability(false, true, true, true, true, true, false))
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

    public Operator pullOperator(int i)
    {
        //returns and removes an operator by their position (using the overloaded (string name) function)
        return pullOperator(operatorList[i].getName());
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
            Debug.Log("Random Number: " + randomNumber);
            //pulls the operator of a random index
            return pullOperator(randomNumber);
        }
        else
            return null;
    }

    /**
     * Operator list to string
     */
    public string toString()
    {
        string message = "Updated Site List\n";

        for(int i=0; i<operatorList.Count; i++)
        {
            message += "" + operatorList[i].getName() + " " + operatorList[i].getCategory()+"\n";
        }

        return message;
    }
}
