let button = document.getElementById("myButton");
let inputSet = Array.from(document.getElementsByClassName("myInput"));
let inputSet = new Set();


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

for (inputElement of inputSet) {
    inputElement.onselectionchange = checkButton;
}
checkButton();