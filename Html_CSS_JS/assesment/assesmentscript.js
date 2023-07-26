function validateName() {
    let name_pattern=/[a-zA-Z\s]/g;
    let name = document.getElementById('name');
    if (name.value == ''|| !name.value.match(name_pattern)) {
        alert('Name field cannot be empty');
    }
}

//validation for contact number
function validateContactNo() {
    let number_pattern=/[789]{1}[0-9]{9}/g;
    let phoneNumber = document.getElementById('mobileNumber');
    if (phoneNumber.value == '' || !phoneNumber.value.match(number_pattern) ){
        alert('Contact number field cannot be empty');
    }
   
   
}
function validateCardNo(){
    let card_number_pattern=/[3-5]{1}[0-9]{15}/g;
    let cardNumber = document.getElementById('cardNumber');
    if(cardNumber.value == '' || !cardNumber.value.match(card_number_pattern)){
        alert("Card Number field cannot be empty");
    }
}
function validatecvv(){
    let cvv_number_pattern=/[0-9]{3}/g;
    let cvvNumber = document.getElementById('cvvNumber');
    if(cvvNumber.value == ''|| !cvvNumber.value.match(cvv_number_pattern) ){
        alert("CVV Number field cannot be empty");
    }
}
//validation for email
function emailValidation() {
    let email_pattern=/[a-z0-9]+@[a-z]+\.[a-z]/g;
    let email = document.getElementById('email');
    if (email.value == ''  || !email.value.match(email_pattern)) {
        alert('Email field cannot be empty');
    }
}

//cost calculation
function costCalculation(){
    let session=document.querySelector('input[name="sessionType"]:checked').value;
    let noofguests=document.getElementById('numberOfGuests').value;
    var date = document.getElementById("dateOfvisit").value;

    let cost;
    let advcost;
    if (session == 'Lunch(12pm-3pm)'){
        if (noofguests <= 3 && noofguests >=2) {
            cost = 500*noofguests;
            advcost=500;
        }
        else if (noofguests >3 && noofguests <=6){
            cost = 1000*noofguests;
            advcost=1000;
        }
        else if (noofguests >6 && noofguests <=10){
            cost =2500 *noofguests;
            advcost=2500;
        }
        else if (noofguests >10 && noofguests <=20){
            cost =4000*noofguests;
            advcost=4000;
        }
    }
    else if (session == 'Dinner(7pm-10pm)'){
        if (noofguests <= 3) {
            cost= 600*noofguests;
            advcost=600;
        }
        else if (noofguests >3 && noofguests <=6){
            cost= 1200*noofguests;
            advcost=1200;
        }
        else if (noofguests >6 && noofguests <=10){
            cost=2750*noofguests;
            advcost=2750;
        }
        else if (noofguests >10 && noofguests <=20){
            cost=4200*noofguests;
            advcost=4200;
        }
    }
    document.getElementById('result').innerHTML =  "The Advanced Amount Rs. " + advcost+ " is paid successfully. Your table is Reserved And confirmed on " + date;
}