using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Image : MonoBehaviour
{
    public int Index; // 내가 직접 저장할 값
    public List<Sprite> ImageList;
    int imageIndex; // CSV에서 담긴 숫자
    void Awake()
    {
        // 모든 이미지를 리스트에 담는다.
        ImageList = Resources.LoadAll("Image", typeof(Sprite)).OfType<Sprite>().ToList();
        
        // CSV에 담긴 이미지 인덱스를 int로 변환 
        int.TryParse(CSVParser.Instance.GetCsvImage(GameManager.Instance.CurrentScene, Index), out imageIndex);
        
        LoadImage(imageIndex);
    }
    private void LoadImage(int _index)
    {       
        transform.GetChild(0).GetComponent<RawImage>().texture = ImageList[_index].texture;
    }
}
