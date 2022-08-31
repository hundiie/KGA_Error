using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScriptController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private TextMeshPro scriptTMP;
    private string scriptText;

    public int Index;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        scriptTMP = GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        scriptText = CSVParser.Instance.GetCsvScript(Index); // CSV���� ��ũ��Ʈ ������
        scriptTMP.text = scriptText;
        meshRenderer.enabled = false;
    }

    // ������ ���� ��Ÿ���� �ؽ�Ʈ
    void OnTriggerEnter(Collider _other)
    {
        meshRenderer.enabled = true;
        TTS.Instance.TTSPlay(scriptText);
    }
    void OnTriggerExit(Collider _other)
    {
        meshRenderer.enabled = false;
    }
}
