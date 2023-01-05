
function convert(){
    //let exeamt = 0.0;
    let input_amount = document.getElementById('txtnumber').value;
    let  from_currency= document.getElementById('country1').value;
    let  to_currency= document.getElementById('country2').value;
    // let exchange = document.getElementById('exchange');
    let converted_amt = document.getElementById('convertedamt');
    switch(from_currency){
        case 'US': {
            switch(to_currency){
                case 'India':{
                    exeamt = input_amount * 83 +" Rs";
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;

                }
                case 'China':{
                    exeamt = input_amount * 7 + ' Yuan';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                case 'Germany':{
                    exeamt = input_amount * 0.94 + 'Euro';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                
            }
        }
        case 'Japan': {
            switch(to_currency){
                case 'India':{
                    exeamt = input_amount * 0.61 + 'Rs';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                case 'China':{
                    exeamt = input_amount * 0.051 + ' Yuan';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                case 'Germany':{
                    exeamt = input_amount * 0.0069 + ' Euro';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                
            }
        }
        case 'Europe': {
            switch(to_currency){
                case 'India':{
                    exeamt = input_amount * 88 + ' Rs';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                case 'China':{
                    exeamt = input_amount * 7.40 + ' Yuan';
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                case 'Germany':{
                    exeamt = input_amount * 1.96 + ' Euro'; 
                    converted_amt.innerHTML = exeamt;
                    return exeamt ;
                }
                
            }
        }
    }

 }

