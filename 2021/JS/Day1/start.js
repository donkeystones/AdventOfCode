let fs = require("fs");

let j = 0;
function IsTheNextNumberIncreased(num1, num2) {
    j++;
    //console.log(j + "Current number to check is: \n" + num1 + " < " + num2);
    if(num1 !== undefined && num2 !== undefined){
        console.log("num1 ("+ num1 +") < num2(" + num2 +  ")")
        return parseInt(num1) < parseInt(num2);
    }
    else return false;
}

function parseTextFileToArr() {
    fs.readFile("input.txt",'utf-8', function(err, data){
        let dataArr = data.split("\n")
        partOne(dataArr);
        partTwo(dataArr);
    });
}

function partOne(dataArr){
    let larger = 0;
    let previousVal = 0;
    let newVal = 0;
    for(let i = 0; i < dataArr.length; i++){
        if(i === 0){
            previousVal = dataArr[i];
        }else{
            newVal = dataArr[i];
            if(IsTheNextNumberIncreased(previousVal, newVal)) larger++;
            previousVal = newVal;
        }
    }
    console.log("Amount of larger numbers are: " + larger)
}

function partTwo(){
    
}


//----------------------PROGRAM I STARTED HERE!------------------------------
parseTextFileToArr();