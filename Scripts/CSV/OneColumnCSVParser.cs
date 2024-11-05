using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class OneColumnCSVParser : MonoBehaviour
{
    // CSV ���� ���
    //public string filePath = "Assets/Resources/CSV/randomPool/Name.csv";
    //public List<string> filePathList;

    public List<TextAsset> files = new List<TextAsset>();

    public void LoadCSVs()
    {
        for (int i = 0; i < files.Count; i++)
        {
            LoadCSV(files[i]);
        }
    }

    void LoadCSV(TextAsset file)
    {
        // ������ �����ϴ��� Ȯ��
        if (file)
        {
            // CSV ������ �о�ͼ� �� ������ �迭�� �и�
            //string[] csvLines = File.ReadAllLines(file);
            string[] csvLines = file.text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);//'\n');


            if (csvLines.Length > 1)
            {
                // ù ��° ������ ���
                string header = csvLines[0];

                List<string> data = new List<string>();
                // �� ������ �����͸� �о ��ųʸ��� ����
                for (int i = 1; i < csvLines.Length; i++)
                {
                    data.Add(csvLines[i]);
                }
                    GameSceneManager.Instance.pool.randomPool.Add(header, data);
            }
            else
            {
                Debug.LogWarning("CSV ���Ͽ� �����Ͱ� �����ϴ�: " + file);
            }
        }
        else
        {
            Debug.LogError("CSV ������ ã�� �� �����ϴ�: " + file);
        }
    }
}
