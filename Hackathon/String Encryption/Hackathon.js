const text = "the quick brown fox jumps over the lazy dog"
const myarray = text.split(" ");
console.log(myarray);

let result ="";
let res = []
let element = []
//take user input
const inputtext = "bangalore";
const len = inputtext.length;
let x = 0;
for (let i = 0; i < myarray.length; i++) {
    element = myarray[i]
    console.log(element,myarray.indexOf(element))
    console.log()
    for (let word = 0; word < element.length; word++) {
        res = element[word];
        console.log(res,element.indexOf(res))
        if(inputtext[x]==res){
            console.log("Letter Position",inputtext[x],i,word);
            x += 1;
        }
    }
    console.log()
    //console.log(inputtext[i],myarray.indexOf(element),element.indexOf(res));
}
console.log();
