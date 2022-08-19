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
    // public string Phase;
    public int Index;
    public string Script;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        textMesh = GetComponent<TextMesh>();
    }
    private void Start()
    {
        // Phase = SceneManager.GetActiveScene().name;
        Script = CSVParser.Instance.GetScriptData(Index).Script;
        textMesh.text = Script;
    }
    void OnTriggerEnter(Collider _other)
    {
        meshRenderer.enabled = true;
    }
    void OnTriggerExit(Collider _other)
    {
        meshRenderer.enabled = false;
    }
}
