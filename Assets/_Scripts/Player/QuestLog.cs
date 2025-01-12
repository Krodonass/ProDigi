using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    public GameObject gameManager;
    public TMP_Text mText;

    public string main = "";
    public string findBase = "";
    public string findLowerPlunger = "";
    public string findLowerCathode = "";
    public string findSleeve = "";
    public string findUpperCathode = "";
    public string findUpperPlunger = "";
    public string findGear = "";
    public string findBrassTop = "";

    public bool placedComponentsInHatch;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mText.text = main + "\n" + findBase + "\n" + findLowerPlunger + "\n" + findLowerCathode + "\n" + findSleeve + "\n" + findUpperCathode + "\n" + findUpperPlunger + "\n" + findGear + "\n" + findBrassTop;

        if (gameManager.GetComponent<GameManager>().allComponentsInHatchGameManager)
        {
            main = "Close Outter Hatch";
        } else if (!gameManager.GetComponent<GameManager>().allComponentsInHatchGameManager && !gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager)
        {
            main = "Locate Components of Patcell and place into tube of Glove Box:";
        }

        if (gameManager.GetComponent<GameManager>().allComponentsInHatchGameManager && !gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager && gameManager.GetComponent<GameManager>().isFloodedGameManager)
        {
            main = "Evacuate Air";
        }


        if (!gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager && gameManager.GetComponent<GameManager>().allComponentsInHatchGameManager && !gameManager.GetComponent<GameManager>().isFloodedGameManager)
        {
            placedComponentsInHatch = true;
            main = "Use Glove Box";
        }

        if (!gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && placedComponentsInHatch && gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager && !gameManager.GetComponent<GameManager>().allAssembledGameManager)
        {
            main = "Use Glove Box";
        } else
        {
            if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager && gameManager.GetComponent<GameManager>().allAssembledGameManager || gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && !gameManager.GetComponent<GameManager>().isOpenOutterHatchGameManager)
            {
                main = "Open Inner Hatch";
            }

            if (gameManager.GetComponent<GameManager>().isUsingGloveboxGameManager && gameManager.GetComponent<GameManager>().isOpenInnerHatchGameManager)
            {
                main = "Place Components inside Glove Box";
            }

            if (gameManager.GetComponent<GameManager>().allComponentsInGloveBoxGameManager && gameManager.GetComponent<GameManager>().isOpenInnerHatchGameManager)
            {
                main = "Close Inner Hatch";
            }

            if (gameManager.GetComponent<GameManager>().allComponentsInGloveBoxGameManager && !gameManager.GetComponent<GameManager>().isOpenInnerHatchGameManager)
            {
                if (!gameManager.GetComponent<GameManager>().assembleBaseGameManager)
                {
                    main = "Assemble Base of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleBaseGameManager && !gameManager.GetComponent<GameManager>().assembleLowerPlungerGameManager)
                {
                    main = "Assemble Lower Plunger of Pat Cell";
                } else if (gameManager.GetComponent<GameManager>().assembleLowerPlungerGameManager && !gameManager.GetComponent<GameManager>().assembleLowerCathodeGameManager)
                {
                    main = "Assemble Lower Cathode of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleLowerCathodeGameManager && !gameManager.GetComponent<GameManager>().assembleSleeveGameManager)
                {
                    main = "Assemble Sleeve of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleSleeveGameManager && !gameManager.GetComponent<GameManager>().assembleUpperCathodeGameManager)
                {
                    main = "Assemble Upper Cathode of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleUpperCathodeGameManager && !gameManager.GetComponent<GameManager>().assembleUpperPlungerGameManager)
                {
                    main = "Assemble Upper Plunger of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleUpperPlungerGameManager && !gameManager.GetComponent<GameManager>().assembleGearGameManager)
                {
                    main = "Assemble Gear of Pat Cell";
                }
                else if (gameManager.GetComponent<GameManager>().assembleGearGameManager && !gameManager.GetComponent<GameManager>().assembleBrassTopGameManager)
                {
                    main = "Assemble Brass Top of Pat Cell";
                }
            }
        }



        if (gameManager.GetComponent<GameManager>().allAssembledGameManager && gameManager.GetComponent<GameManager>().isOpeneingInnerHatchGameManager && !gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager)
        {
            main = "Place Pat Cell into tube of Glove Box";
        }

        if (gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && !gameManager.GetComponent<GameManager>().isOpeneingInnerHatchGameManager && gameManager.GetComponent<GameManager>().isEvacuatedGameManager)
        {
            main = "Flood Air";
        }

        if (gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && !gameManager.GetComponent<GameManager>().isOpeneingInnerHatchGameManager && gameManager.GetComponent<GameManager>().isFloodedGameManager)
        {
            main = "Open Outter Hatch";
        }

        if (gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && gameManager.GetComponent<GameManager>().isOpeneingInnerHatchGameManager)
        {
            main = "Close Inner Hatch";
        }


        if (gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && gameManager.GetComponent<GameManager>().isOpeneingOutterHatchGameManager)
        {
            main = "Take assembled Pat Cell";
        }

        if (!gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && gameManager.GetComponent<GameManager>().isOpeneingOutterHatchGameManager && gameManager.GetComponent<GameManager>().allAssembledGameManager)
        {
            main = "Close Outter Hatch";
        }

        if (!gameManager.GetComponent<GameManager>().assembledPatCellInWorkplaceGameManager && !gameManager.GetComponent<GameManager>().assembledPatCellInHatchGameManager && !gameManager.GetComponent<GameManager>().isOpeneingOutterHatchGameManager && gameManager.GetComponent<GameManager>().allAssembledGameManager)
        {
            main = "";
        }

        if (!placedComponentsInHatch) {
            if (gameManager.GetComponent<GameManager>().basePlacedInOuterHatchGameManager)
            {
                findBase = "";
            } else
            {
                findBase = "Base";
            }

            if (gameManager.GetComponent<GameManager>().lowerPlungerPlacedInOuterHatchGameManager)
            {
                findLowerPlunger = "";
            }
            else
            {
                findLowerPlunger = "Lower Plunger";
            }

            if (gameManager.GetComponent<GameManager>().lowerCathodePlacedInOuterHatchGameManager)
            {
                findLowerCathode = "";
            }
            else
            {
                findLowerCathode = "Positive Lower Cathode";
            }

            if (gameManager.GetComponent<GameManager>().sleevePlacedInOuterHatchGameManager)
            {
                findSleeve = "";
            }
            else
            {
                findSleeve = "Sleeve";
            }

            if (gameManager.GetComponent<GameManager>().upperCathodePlacedInOuterHatchGameManager)
            {
                findUpperCathode = "";
            }
            else
            {
                findUpperCathode = "Negative Upper Cathode";
            }

            if (gameManager.GetComponent<GameManager>().upperPlungerPlacedInOuterHatchGameManager)
            {
                findUpperPlunger = "";
            }
            else
            {
                findUpperPlunger = "Upper Plunger";
            }

            if (gameManager.GetComponent<GameManager>().gearPlacedInOuterHatchGameManager)
            {
                findGear = "";
            }
            else
            {
                findGear = "Gear";
            }

            if (gameManager.GetComponent<GameManager>().brassTopPlacedInOuterHatchGameManager)
            {
                findBrassTop = "";
            }
            else
            {
                findBrassTop = "Brass Top";
            }
        }
    }
}
