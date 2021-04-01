using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//FROM BRACKEYS - https://www.youtube.com/watch?v=XOjd_qU2Ido

public class SaveSystem 
{
    /**
     * Saves the List of Schedules into a serializable file format "PlayerData"
     */
    public static void SaveScheduleList(List<Schedule> schedule)///TODO - change to saving the schedule
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/schedule.data";//location of file (different for OSs)
        FileStream stream = new FileStream(path, FileMode.Create);

        ScheduleData data = new ScheduleData(schedule);//gives the PlayerData class the schedule for serialization

        formatter.Serialize(stream, data);//inserting the serializable class into the file
        stream.Close();//closing the stream
    }

    /**
     * Loads the serializable PlayerData from the binary file
     * Returns the data in  PlayerData format
     */
    public static ScheduleData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/schedule.data";//location of file (different for OSs)
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            ScheduleData data = formatter.Deserialize(stream) as ScheduleData;//returning it from a serialized format
            stream.Close();

            return data;

        } else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
