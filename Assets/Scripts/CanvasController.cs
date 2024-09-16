using UnityEngine;
using UnityEngine.UI;
using SimpleLibrary;

public class CanvasController : MonoBehaviour
{
    private const string UNKNOWN_OPERATION = "UNKNOWN OPERATION";
    private const string ERROR = "ERROR";

    private const int ADD = 0;
    private const int SUBSTRACT = 1;
    private const int MULTIPLY = 2;
    private const int DIVIDE = 3;
    
    // Inspector
    public InputField input1;
    public InputField input2;
    public Dropdown operation;
    public Text result;

    public void Compute()
    {
        bool factor1Parsed = float.TryParse(input1.text, out float factor1);
        bool factor2Parsed = float.TryParse(input2.text, out float factor2);

        if (factor1Parsed && factor2Parsed) {
            switch (operation.value)
            {
                case ADD:
                    result.text = SimpleMath.Add(factor1, factor2).ToString();
                    break;
                case SUBSTRACT:
                    result.text = SimpleMath.Substract(factor1, factor2).ToString();
                    break;
                case MULTIPLY:
                    result.text = SimpleMath.Multiply(factor1, factor2).ToString();
                    break;
                case DIVIDE:
                    result.text = SimpleMath.Divide(factor1, factor2).ToString();
                    break;
                default:
                    result.text = UNKNOWN_OPERATION;
                    break;
            }
        }
        else
        {
            if (!factor1Parsed)
            {
                input1.image.color = Color.red;
            }
            if (!factor2Parsed)
            {
                input2.image.color = Color.red;
            }
            result.text = ERROR;
        }

    }

    public void ResetInput1Color()
    {
        input1.image.color = Color.white;
    }

    public void ResetInput2Color()
    {
        input2.image.color = Color.white;
    }

}
