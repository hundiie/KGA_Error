using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class ImageController : MonoBehaviour
{
    public List<Sprite> ImageList;

    private RoomController roomController;
    private int imageIndex; // CSV에서 담긴 숫자

    private void Awake()
    {
        roomController = GetComponentInParent<RoomController>();
    }
    void Start()
    {
        // 모든 이미지를 리스트에 담는다.
        ImageList = Resources.LoadAll("Image", typeof(Sprite)).OfType<Sprite>().ToList();
        imageIndex = CSVParser.Instance.GetCsvImage((int)roomController.roomInfo);
        LoadImage(imageIndex);        
    }
    private void LoadImage(int _index)
    {       
        transform.GetChild(0).GetComponent<RawImage>().texture = ImageList[_index].texture;
    }
}

