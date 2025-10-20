using UnityEngine;

public class HeroPartyManager : MonoBehaviour
{
    public static HeroPartyManager instance;

    [Header("PartSO Reference")]
    [SerializeField] private PlayerPartySO playerPartySO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public PlayerPartySO GetPlayerPartySO()
    {
        return playerPartySO;
    }
}
