using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class WordManager : MonoBehaviour
{
    public List<string> words = new List<string>() {"cat"};
    public int currentWordIndex = 0;
    public Text displayTextCurrentWord;
    public Text displayTextTimer;
    public Text displayTextWin;

    private HashSet<char> currentWordSet;
    private float startTime;

    public void Start()
    {
        Debug.Log("Current word: " +  words[0]);
        currentWordSet = new HashSet<char>(words[0]);
        displayTextCurrentWord.text = "Current Word is: "+ "'" + words[0] + "'";
        //displayTextWin.text = "You Win!";
        displayTextWin.enabled = false;
        displayTextTimer.enabled = false;
        startTime = Time.time;
        
    }

    public void Update()
    {
        float t = Time.time - startTime;
        string seconds = (t % 60).ToString("f2");
        //displayTextTimer.text = "Time: " + seconds + "s";
    }


    public string GetCurrentWord()
    {
        return words[currentWordIndex];
    }
    
    public bool IsValidLetterHit(char letter)
    {

        if (currentWordSet.Contains(letter))
        {
            currentWordSet.Remove(letter);
            if (currentWordSet.Count == 0)
            {
                HandleWordCompletion();
            }
            return true;
        }
        
        return false;
    }

    private void HandleWordCompletion()
    {
        Debug.Log("Word Completed: " + words[currentWordIndex]);
        currentWordIndex++;
        

        // Check if we have more words
        if (currentWordIndex < words.Count){
            Debug.Log("Current word: " +  words[currentWordIndex]);
            currentWordSet = new HashSet<char>(words[currentWordIndex]);
            displayTextCurrentWord.text = "Current Word is: "+ "'" + words[currentWordIndex] + "'";
        }
        else
        {
            Debug.Log("All words completed! You win!");
            //displayTextWin.enabled = true;
        }
    }
    
}