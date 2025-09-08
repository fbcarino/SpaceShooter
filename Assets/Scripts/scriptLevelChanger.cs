using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptLevelChanger : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToScene (int levelIndex)
    {
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene("sceneBossLevel");
    }
}
