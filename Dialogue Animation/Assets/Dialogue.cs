using System.Collections;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class Dialogue : MonoBehaviour
{
    
    
    
    public TextMeshProUGUI dialogueText; 
    
    
    public string[] sentences;

    
    public float typingSpeed = 0.05f;

    
    private int index = 0; 
    private Coroutine typingCoroutine; 

    

    
    
    
    void Start()
    {
        
        

        
        Debug.Log("Press 'Space' to start dialogue.");
    }

    
    
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (typingCoroutine == null)
            {
                
                if (index < sentences.Length)
                {
                    StartDialogue();
                }
                else
                {
                    
                    Debug.Log("End of dialogue.");
                    dialogueText.text = ""; 
                }
            }
            
            else
            {
                
                StopCoroutine(typingCoroutine);
                typingCoroutine = null;

                
                dialogueText.text = sentences[index - 1]; 
            }
        }
    }


    

    
    
    
    public void StartDialogue()
    {
        if (index < sentences.Length)
        {
            
            typingCoroutine = StartCoroutine(TypeSentence(sentences[index]));
            
            index++;
        }
    }

    

    
    
    
    
    IEnumerator TypeSentence(string sentence)
    {
        
        dialogueText.text = "";

        
        foreach (char letter in sentence.ToCharArray())
        {
            
            dialogueText.text += letter;
            
            
            yield return new WaitForSeconds(typingSpeed);
        }

        
        typingCoroutine = null;
    }
}

