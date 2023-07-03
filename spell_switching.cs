using UnityEngine;

public class spell_switching : MonoBehaviour
{

    public int selectedSpell = 0;
    private bool fbTalent = false;
    private bool fbRightTalent = false;

    // Start is called before the first frame update
    void Start()
    {
        SelectSpell();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSpell = selectedSpell;

        if(fbTalent == true || fbRightTalent == true)
        {

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(selectedSpell >= transform.childCount - 1)
            {
                selectedSpell = 0;
            }else
            {
                selectedSpell++;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if(selectedSpell <= 0)
            {
                selectedSpell = transform.childCount - 1;
            }else
            {
                selectedSpell--;
            }
        }
        
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSpell = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)  && (fbTalent == true || fbRightTalent == true))
        {
            selectedSpell = 1;
        }

        if(previousSpell != selectedSpell)
        {
            SelectSpell();
        }

    }

    void SelectSpell()
    {
        int i = 0;
        foreach(Transform spell in transform)
        {
            if(i == selectedSpell)
            {
                spell.gameObject.SetActive(true);
            } else
            {
                spell.gameObject.SetActive(false);
            }
            i++;
        }
    }

    public void AddFireBallSpell()
    {
        fbTalent = true;
    }

    public void AddRightClickFireBallSpell()
    {
        fbRightTalent = true;
    }
}
