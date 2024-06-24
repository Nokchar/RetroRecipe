using TMPro;
using UnityEngine;

namespace HSJ
{
    public class PlayerController : MonoBehaviour
    {
	    public enum PlayerState
	    {
		    Ready,
		    Open,
            Order,
		    Cooking,
            Complete,
		    Close
	    }

	    private PlayerState state;
	    public PlayerState State
        { 
            get
            { 
                return state;
            }
        }

        private TMP_Text stateText;

        private void Awake()
        {
		    stateText = GetComponentInChildren<TMP_Text>();
        }

        private void Start()
        {
		    state = PlayerState.Ready;
        }

        private void Update()
        {
		    stateText.text = state.ToString();

            if (Input.GetKeyDown(KeyCode.Q))
		    {
			    state = PlayerState.Open;
		    }

            if (Input.GetKeyDown(KeyCode.W))
            {
                state = PlayerState.Order;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                state = PlayerState.Cooking;
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                state = PlayerState.Complete;
            }
        }
    }
}
