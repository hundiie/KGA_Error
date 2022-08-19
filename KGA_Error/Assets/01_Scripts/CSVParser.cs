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
    private Dictionary<int, DataTable> dataTable = new Dictionary<int, DataTable>();
    private void Awake()
    {
        // 1. 리소스 폴더에서 csv 로드
        TextAsset csvTextAsset = Resources.Load<TextAsset>("CSV/DataTable");

        // 2. csv파일 설정 - CsvReader의 매개변수 Configuration에 들어갈 변수
        CsvConfiguration config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = "|", // 컬럼설정
            NewLine = Environment.NewLine // 개행문자 설정
        };

        // 이곳이 병목지점이 될 수 있음을 주의
        using (StringReader cswString = new StringReader(csvTextAsset.text)) // 파싱한 csv를 읽어온다.
        {
            using (CsvReader csv = new CsvReader(cswString, config))
            {
                IEnumerable<DataTable> records = csv.GetRecords<DataTable>();
                foreach (DataTable record in records)
                {
                    if (false == dataTable.ContainsKey(record.Index))
                    {
                        dataTable[record.Index] = record;

                        // HACK : index는 1부터 시작하기에 0번 요소를 빈 값으로 채움
                        dataTable[record.Index] = null;
                    }
                    dataTable[record.Index] = record;
                }
            }
        }
    }
    public DataTable GetCsvData(int _index) // 인덱스로 원하는 데이터를 찾는다.
    {
        return dataTable[_index];
    }
}