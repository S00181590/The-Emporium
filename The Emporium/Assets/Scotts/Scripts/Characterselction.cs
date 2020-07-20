using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterselction : MonoBehaviour
{
    public GameObject MaleCharacter;
    public GameObject FemaleCharacter;

    private Vector3 CharacterPos;//pos where the charcther is placed  on the screen
    private Vector3 CharacterPosOffScreen;//pos where the charcther is placed off the screen 
    public int CharacterNumber = 1;
    private SpriteRenderer MaleCharacterrender, FemaleCharacterrender;// useing the spriye render to only draw one sprite o the screen when the selection button is pressed helps save on perfomance
    private void Awake()
    {
        CharacterPos = MaleCharacter.transform.position;//saveing the MaleCharacter thats on the screen position before the game is loaded  
        CharacterPosOffScreen = FemaleCharacter.transform.position;//saveing the offscreen character pos
        MaleCharacterrender = MaleCharacter.GetComponent<SpriteRenderer>();
        FemaleCharacterrender = FemaleCharacter.GetComponent<SpriteRenderer>();

    }

    public void NextCharacter()
    {
        switch (CharacterNumber)
        {
            case 1:
                MaleCharacterrender.enabled = false;
                MaleCharacter.transform.position = CharacterPosOffScreen;//moves the chracther form the screen to the offscrennn pos 
                FemaleCharacter.transform.position = CharacterPos;
                FemaleCharacterrender.enabled = true;
                CharacterNumber++;//allows it to move to the case numbers when you cick the button 
                 break;
            case 2:
                FemaleCharacterrender.enabled = false;
                FemaleCharacter.transform.position = CharacterPosOffScreen;//moves the chracther form the screen to the offscrennn pos 
                MaleCharacter.transform.position = CharacterPos;
                MaleCharacterrender.enabled = true;
                CharacterNumber++;//allows it to move to the case numbers
                ResetCharacternumber();
                break;

            default:
                ResetCharacternumber();//incase someting goes wrong resets the character seleection
                    break;
        }
    }
    public void PreviousCharacter()
    {
        switch (CharacterNumber)
        {
            case 1:
                
                MaleCharacterrender.enabled = false;
                MaleCharacter.transform.position = CharacterPosOffScreen;//moves the chracther form the screen to the offscrennn pos 
                FemaleCharacter.transform.position = CharacterPos;
                FemaleCharacterrender.enabled = true;
                ResetCharacternumber();
                break;
            case 2:
                MaleCharacterrender.enabled = false;
                MaleCharacter.transform.position = CharacterPosOffScreen;//moves the chracther form the screen to the offscrennn pos 
                FemaleCharacter.transform.position = CharacterPos;
                FemaleCharacterrender.enabled = true;
                CharacterNumber--;//useing -- to go back instead of foward 
                break;

            default:
                ResetCharacternumber();
                break;
        }
    }

    private void ResetCharacternumber()//allows you to cylcye through the  character again 
    {
        if(CharacterNumber >=2)
        {
            CharacterNumber = 1;
        }
        else
        {
            CharacterNumber = 2;
        }
    }
}
