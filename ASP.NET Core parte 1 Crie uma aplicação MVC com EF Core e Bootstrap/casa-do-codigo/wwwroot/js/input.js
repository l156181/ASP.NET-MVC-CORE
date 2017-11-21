class ShoppingCart{    
   
    getInput(classInput){
        return document.querySelectorAll(classInput);
    }

    attachFunctionForEventClick(inputs){
        inputs.forEach(function(input) {
            var self = this;
            input.addEventListener("change", function(){
                self.increment(this);
            });
        },this);
    }

    increment(input){
        var data = this.getData(input);
        this.postQuantity(data);
    }
    
    getData(input){
        // Get parent element of the button(varialble this) that
        // Contains defined the attributte item-id
        var parentItem = $(input).parents('[item-id]');
    
        // Get value of attributte item-id of element referenced by
        // variable parentItem
        var itemId = parentItem.attr('item-id');
    
        //Get the value of the child element that is of the type input 
        //parentItem.find('input').val();
    
        var data = {
            Id: itemId,
            Quantity: input.value
        };
        
        return data;
    }
    
    postQuantity(data){
        var token = $('input[name=__RequestVerificationToken]').val();
        var header = {};
        header['RequestVerificationToken'] = token;
        $.ajax({
            url: '/request/postquantity',
            type: 'POST',
            contentType: 'application/json',
            headers: header,
            data: JSON.stringify(data)
        }).done(function(response){
            console.log("Quantidade " + response.order.quantity)
            
            this.setQuantidade(response.order);
            this.setSubtotal(response.order);
            this.setTotal(response.shoppingCartViewModel);
            this.setItemNumber(response.shoppingCartViewModel);

            if(response.order.quantity == 0){
                this.removeItem(response.order);
            }
        }.bind(this));
    }

    // Set HTML element content that contais the quantity information
    setQuantidade(order){
        this.getOrderLine(order).find('input').val(order.quantity);
    }

    // Set subtotal information with the content of the order parameter
    // Parameter is an object of the class Order
    setSubtotal(order){
        this.getOrderLine(order).find('[subtotal]').html(order.subTotal.setContentTwoDecimalPlaces());
    }
    
    // Get HTML element that contains the informations of the object order
    // Parameter is an object of the class Order
    getOrderLine(order){
        return $('[item-id='+order.id + ']');
    }

    // Set value of the total element of the order
    setTotal(shoppingCart){
        $('[total]').html(shoppingCart.total.setContentTwoDecimalPlaces());
    }

    // Remove order line represent by parameter
    removeItem(order){
        this.getOrderLine(order).remove();
    }

    setItemNumber(shoppingCartViewModel){
        var itensNumber  = shoppingCartViewModel.itens.length;
        var texto = "Total: " 
                    + itensNumber
                    + " "   
                    + ((itensNumber < 2)? 'item' : 'itens');
        $('[number-itens]').html(texto);
    }
}

Number.prototype.setContentTwoDecimalPlaces = function(){
    return this.toFixed(2).replace('.',",");
}

var shoppingCart = new ShoppingCart();
var inputs = shoppingCart.getInput(".input-quantity.text-center.form-control");
shoppingCart.attachFunctionForEventClick(inputs);
