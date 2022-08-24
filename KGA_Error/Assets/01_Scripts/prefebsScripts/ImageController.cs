using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ImageController : MonoBehaviour
{
    public int RoomIndex; // 내가 직접 지정할 방 번호
    public List<Sprite> ImageList;

    private int imageIndex; // CSV에서 담긴 숫자
    void Start()
    {
        // 모든 이미지를 리스트에 담는다.
        ImageList = Resources.LoadAll("Image", typeof(Sprite)).OfType<Sprite>().ToList();
        
        // CSV에 담긴 이미지 인덱스를 int로 변환 
        int.TryParse(CSVParser.Instance.GetCsvImage(RoomIndex), out imageIndex);
        
        LoadImage(imageIndex);
    }
    private void LoadImage(int _index)
    {       
        transform.GetChild(0).GetComponent<RawImage>().texture = ImageList[_index].texture;
    }
}

