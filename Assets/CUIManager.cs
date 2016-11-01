using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CUIManager : MonoBehaviour {

    public Animator _rightPanel;

    bool _isShow = false;

    public void OnCharacterPanelShow()
    {
        _isShow = !_isShow;
        
        _rightPanel.SetBool("Show", _isShow);
        
            
    }

}
