using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private TextMesh textMesh;

    public int Index;
    public string Script;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        textMesh = GetComponent<TextMesh>();
    }
    private void Start()
    {
        Script = CSVParser.Instance.GetCsvScript(GameManager.Instance.CurrentScene, Index); // CSV에서 스크립트 가져옴
        textMesh.text = Script;
    }

    // 가까이 가면 나타나는 텍스트
    void OnTriggerEnter(Collider _other)
    {
        meshRenderer.enabled = true;
    }
    void OnTriggerExit(Collider _other)
    {
        meshRenderer.enabled = false;
    }
}
