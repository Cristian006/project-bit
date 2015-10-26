using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Add this script to a UI button and drag in the panel you want to toggle
/// </summary>
public class TogglePanel : MonoBehaviour
{
    //Button to click to toggle panel
    private Button toggler;
    //panel to toggle on or off
    public GameObject Panel2Toggel;
    //Should the UI element be active at start or hidden until button is clicked
    public bool activeOnStart = false;
    
	void Awake ()
    {
        toggler = GetComponent<Button>();

        toggler.onClick.AddListener(() => {
            Toggel();
        });

        if (activeOnStart)
        {
            Panel2Toggel.SetActive(true);
        }
        else
        {
            Panel2Toggel.SetActive(false);
        }

    }
	
	public void Toggel()
    {
        if (Panel2Toggel != null)
        {
            if (Panel2Toggel.gameObject.activeInHierarchy)
            {
                Panel2Toggel.SetActive(false);
            }
            else
            {
                Panel2Toggel.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Toggel Element not found in ToggelPanel Script on " + this.gameObject.name);
        }
    }
}
