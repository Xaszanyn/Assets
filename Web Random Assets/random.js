f(0, 0, 0, 0);

function f(amount, zeros, ones, corrects)
{
    setTimeout(function(){
        
        
        
        amount++;
    
    let guess;
    if (zeros > ones) guess = 1;
    else if (ones > zeros) guess = 0;
    else guess = Math.floor(Math.random() * 2);
    
    let event = Math.floor(Math.random() * 2);
    if (event == 0) zeros++;
    else if (event == 1) ones++;
    
    if (event == guess) corrects++;
    
    //let message = confirm(event + " <- (" + guess + ")\n\n" + "CORRECTS " + corrects + "\nTOTAL " + amount + "\nRANDOM RATIO " + zeros / ones + "\nRATIO " + corrects / amount + "\nZ/O " + zeros + ":" + ones);
        
        
    console.log(event + " <- (" + guess + ")\n\n" + "CORRECTS " + corrects + "\nTOTAL " + amount + "\nRANDOM RATIO " + zeros / (ones * 2) + "\nRATIO " + corrects / amount + "\nZ/O " + zeros + ":" + ones);
    
    
    
    /* if (message) */ f(amount, zeros, ones, corrects);
        
        
        
        
        
        
        
    }, 10);
    
    
    
}