using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneCSV : MonoBehaviour
{
    public TextAsset csvFile;
    public Queue<CSVData> csvDataQueue = new Queue<CSVData>();
    public Dictionary<int, Queue<CSVData>> GSdicData = new Dictionary<int, Queue<CSVData>>();

    string[] csvLine;
    string[] splitData;


    private IEnumerator Start()
    {
        csvLine = csvFile.text.Split('\n');

        for (int i = 1; i < csvLine.Length; ++i)
        {
            if (string.IsNullOrWhiteSpace(csvLine[i]))
                continue;

            splitData = csvLine[i].Split(',');

            CSVData data = new CSVData
            {
                dialogueNum = int.Parse(splitData[0]),
                id = int.Parse(splitData[1]),
                speakers = splitData[2],
                content = splitData[3]
            };
                       

            if (!GSdicData.ContainsKey(data.dialogueNum))
            {
                GSdicData[data.dialogueNum] = new Queue<CSVData>();
            }

            GSdicData[data.dialogueNum].Enqueue(data);
        }

        yield return null;
    }
}
