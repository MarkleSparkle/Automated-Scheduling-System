using System;
using UnityEngine;
using UnityEngine.UI;

//this is NOT an object because there is only ONE selected Site at a time
public class SelectedSite : MonoBehaviour
{
    private static Site selectedSite;

    /**
     * Accessor method for selectedSite
     */
    public static Site getSelectedSite()
    {
        return selectedSite;
    }

    /**
     * Mutator method for selectedSite
     */
    public void setselectedSite(Button button)
    {
        string buttonName = button.name;
        Debug.Log(buttonName);

        selectedSite = new Site(button.name, Category.Low);
    }

}
