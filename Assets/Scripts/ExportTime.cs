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
    public string MapID;
    public string Warning;
    public string notificationType;
    public string CorrentAnswer;
    public string notificationColor;
    public string speed;
    private Decimal prev;

    void Start()
    {
        addHeaders();
    }

    public void addHeaders()
    {
        sb.AppendLine("MapID;NotificationType;NotificationColor;Warning;Speed;CorrentAnswer;Answer;Time");
    }

    public void recordYes()
    {
        decimal time = Decimal.Round((decimal)Time.time, 4);
        if (prev == time) return;
        sb.AppendLine(MapID + ";" + notificationType + ";" + notificationColor + ";" + Warning + ";" + speed + ";" + CorrentAnswer + ";" + "Yes;" + time.ToString());
        SaveToFile(sb.ToString());
        prev = time;
    }

        public void recordNo()
    {
        decimal time = Decimal.Round((decimal)Time.time, 4);
        if (prev == time) return;
        sb.AppendLine(MapID + ";" + notificationType + ";" + notificationColor + ";" + Warning + ";" + speed + ";" + CorrentAnswer + ";" + "No;" + time.ToString());
        SaveToFile(sb.ToString());
        prev = time;
    }

    public void SaveToFile(string content)
    {
        var folder = Application.streamingAssetsPath;
        folder = folder.Replace("/StreamingAssets", "");
        folder = folder + "/Results/Participant" + ParticipantID;

        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);


        var filePath = Path.Combine(folder, "export map" + MapID + ".csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }
    }
}
