using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

public class DataTable // 실제 데이터와 이름이 같아야한다.
{
    public int Index { get; set; }
    public string Script { get; set; }
    public string B1 { get; set; }
    public string B2 { get; set; }
    public string Image { get; set; }
    public string BGM { get; set; }
}
public class CSVParser : SingletonBehaviour<CSVParser>
{
    private Dictionary<int, DataTable> scriptTable = new Dictionary<int, DataTable>();
    private void Awake()
    {
        // 1. 리소스 폴더에서 csv 로드
        TextAsset scriptTextAsset = Resources.Load<TextAsset>("CSV/Error - DataTable");

        // 2. csv파일 설정 - CsvReader의 매개변수 Configuration에 들어갈 변수
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
                IEnumerable<DataTable> records = csv.GetRecords<DataTable>();
                foreach (DataTable record in records)
                {
                    if (false == scriptTable.ContainsKey(record.Index))
                    {
                        scriptTable[record.Index] = record;

                        // HACK : index는 1부터 시작하기에 0번 요소를 빈 값으로 채움
                        scriptTable[record.Index] = null;
                    }
                    scriptTable[record.Index] = record;
                }
            }
        }
    }
    public DataTable GetScriptData(int _index)
    {
        return scriptTable[_index];
    }
}