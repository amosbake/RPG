using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellBook : MonoBehaviour {
    [SerializeField]
    private Spell[] spells;
    [SerializeField]
    private Image castingBar;
    [SerializeField]
    private Text spellName;
    [SerializeField]
    private Image spellIcon;
    [SerializeField]
    private Text castTime;
    [SerializeField]
    private CanvasGroup canvasGroup;
    private Coroutine spellCoroutine;
    private Coroutine fadeCoroutine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Spell CastSpell(int index)
    {
        Spell spell = spells[index];
        castingBar.color = spell.BarColor;
        castingBar.fillAmount = 0;
        spellName.text = spell.Name;
        spellIcon.sprite = spell.Icon;
        spellCoroutine = StartCoroutine(Progress(index));
        fadeCoroutine =  StartCoroutine(FadeBar());
        return spells[index];
    }

    public void StopCasting()
    {
        if (spellCoroutine!=null)
        {
            StopCoroutine(spellCoroutine);
            spellCoroutine = null;
        }
        if(fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            canvasGroup.alpha = 0;
        }
    }



    private IEnumerator Progress(int index)
    {
        float timePassed = Time.deltaTime;
        float rate = 1 / spells[index].CastTime;
        float progress = 0f;
        while(progress < 1f)
        {
            castingBar.fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            timePassed += Time.deltaTime;
            //10.12
            castTime.text = Mathf.Max(0,(spells[index].CastTime - timePassed)).ToString("F2");
            yield return null;
        }
        StopCasting();
    }

    IEnumerator FadeBar()
    {
        float timeLeft = Time.deltaTime;
        float rate = 1;
        float progress = 0f;
        while (progress < 1f)
        {
            canvasGroup.alpha = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;
            yield return null;
        }
    }
}
