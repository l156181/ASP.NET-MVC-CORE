var inputs = getInput(".input-quantity.text-center.form-control");

attachMethodForEventClick(inputs);

function getInput(classInput){
    return document.querySelectorAll(classInput);
}

function attachMethodForEventClick(inputs){
    inputs.forEach(function(input) {
        input.addEventListener("click",increment);
    }, this);
}

function increment(){
    // Get parent element of the button(varialble this) that
    // Contains defined the attributte item-id
    var parentItem = $(this).parents('[item-id]');

    // Get value of attributte item-id of element referenced by
    // variable parentItem
    var itemId = parentItem.attr('item-id');

    //Get the value of the child element that is of the type input 
    //parent.find('input').val();
    $.ajax({
        url: '/request/postquantity'
    })

    console.log(itemId);
    console.log(this.value);
}