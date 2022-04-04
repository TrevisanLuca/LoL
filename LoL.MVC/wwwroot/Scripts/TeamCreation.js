document.addEventListener("DOMContentLoaded", () => {
    let button = document.getElementById("myButton");
    let inputArray = Array.from(document.getElementsByClassName("myInput"));
    let inputSet = new Set();
    let oldPlayersCache = [];
    let arrayCounter = 0;


    function checkButton() {
        inputSet.clear();
        inputArray.forEach(x => inputSet.add(x.value));
        if (inputSet.size === 5) {
            button.disabled = false;
        }
        else {
            button.disabled = true;
        }
    };

function disableUsedPlayers(thisElement) {
    let usedPlayer = thisElement.options[thisElement.options.selectedIndex].value;
    for (element of inputArray) {
        if (element != thisElement) {
            for (option of element.options) {
                if (option.value === usedPlayer) {
                    option.hidden = true;
                }
                else if (option.value === oldPlayersCache[thisElement.arrayIndex]) {
                    option.hidden = false;
                }
            }
        }
    }
    oldPlayersCache[thisElement.arrayIndex] = usedPlayer;
    }

    //setUp
    for (let inputElement of inputArray) {
        inputElement.onchange = () => {
            checkButton();
            disableUsedPlayers(inputElement);
        };
        inputElement.arrayIndex = arrayCounter;
        disableUsedPlayers(inputElement);
        arrayCounter = arrayCounter + 1;
    }
    checkButton();
});