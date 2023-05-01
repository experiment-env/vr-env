using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class ExportTime : MonoBehaviour
{
   
    public StringBuilder sb = new System.Text.StringBuilder();
    private string contentData;
    public string ParticipantID;

    void Start()
    {
        addHeaders();
    }

    public void addHeaders()
    {
        sb.AppendLine("Type;Corrent answer;Answer;Time");
    }

    public void recordYes()
    {
        decimal time = Decimal.Round((decimal)Time.time, 4);
        sb.AppendLine("Head;" + "No;" + "Yes;" + time.ToString());
        SaveToFile(sb.ToString());
    }

        public void recordNo()
    {
        decimal time = Decimal.Round((decimal)Time.time, 4);
        sb.AppendLine("Head;" + "No;" + "No;" + time.ToString());
        SaveToFile(sb.ToString());
    }

    public void SaveToFile(string content)
    {
        var folder = Application.streamingAssetsPath;

        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);


        var filePath = Path.Combine(folder, "export " + ParticipantID + ".csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }
    }
}
