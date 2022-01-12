using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [System.Serializable]
    public enum idiom
    {
        pt,
        eng,
        spa
    }

    public idiom lenguage;

    [Header("Components")]
    public GameObject dialogueObj; //janela do dialogo
    public Image profileSprite; //sprite do perfil
    public Text speechText; //texto da fala
    public Text actorNameText; //nome do npc

    [Header("Settings")]
    public float typingSpeed; //velocidade da fala

    //Vari�veis de controle
    private bool isShowing; //se a janela est� vis�vel
    private int index; //index das senten�as
    private string[] sentences;

    public static DialogueControl instance;

    //awake � chamado antes de todos os Start() na hierarquia de execu��o de scripts
    private void Awake()
    {
        instance = this;
    }

    //� chamado ao inicializar
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    IEnumerator TypeSentence()
    {
        foreach(char latter in sentences[index].ToCharArray())
        {
            speechText.text += latter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    //pular para pr�xima frase/fala
    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            index++;
            speechText.text = "";
            StartCoroutine(TypeSentence());
        }
        else
        {
            speechText.text = "";
            index = 0;
            dialogueObj.SetActive(false);
            sentences = null;
            isShowing = false;
        }
    }

    //chamar a fala
    public void Speech(string[] txt)
    {
        if (!isShowing)
        {
            dialogueObj.SetActive(true);
            sentences = txt;
            StartCoroutine(TypeSentence());
            isShowing = true;
        }
    }
}
