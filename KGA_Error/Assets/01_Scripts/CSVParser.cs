using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
public class ScriptData // 실제 데이터와 이름이 같아야한다.
{
    public string phase { get; set; }
    public int index { get; set; } 
    public string script { get; set; }
}
public class CSVParser : MonoBehaviour
{
    private void Start()
    {
        // 1. 리소스 폴더에서 csv 로드
        TextAsset scriptTextAsset = Resources.Load<TextAsset>("CSV/Error - Script"); 

        // 
        //CsvReader의 두번째 매개변수인 Configuration에 들어갈 매개변수
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|", // 컬럼설정
            NewLine = Environment.NewLine // 개행문자 설정
        };

        // 이곳이 병목지점이 될 수 있음을 주의
        using (StringReader cswString = new StringReader(scriptTextAsset.text)) // 파싱한 csv를 읽어온다.
        {
            using (CsvReader csv = new CsvReader(cswString, config))
            {
                IEnumerable<ScriptData> records = csv.GetRecords<ScriptData>();
                foreach (ScriptData record in records)
                {
                    Debug.Log($"{record.phase} : {record.index} : {record.script}");
                }
            }
        }
        // cswString.Dispose(); // 파일을 열었으면 늘 파일을 닫아줘야함
        // csv.Dispose();
        // 근데 이걸 빼먹을 수 있기 때문에 자동으로 Dispose를 호출해주는 using구문을 사용한다.
    }
}