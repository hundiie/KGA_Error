using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
enum EScriptID
{
    INTRO_1 = 1001,
    INTRO_2 = 1002,
    INTRO_3 = 1003,
    INTRO_4 = 1004,
    INTRO_5 = 1004,
    INTRO_6 = 1005,
    INTRO_7 = 1006,

    PHASE1_FACE = 2001,
    PHASE1_SOUND = 2002,
    PHASE1_MORAL = 2003,
    PHASE1_WINDOW = 2004
}
public class TextController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private TextMesh textMesh;

    public int Index;
    public int Phase;
    public string Script;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        textMesh = GetComponent<TextMesh>();
    }
    private void Start()
    {
        Script = CSVParser.Instance.GetCsvData(Index).Script; // CSV에서 스크립트 가져옴
        Phase = Index / 1000;
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
