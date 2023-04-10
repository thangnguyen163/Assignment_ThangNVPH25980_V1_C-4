       function decreaseQuantity() {
        var quantityInput = document.getElementById("quantity");
        var quantity = parseInt(quantityInput.value);
        if (quantity > 1) {
            quantity--;
        }
        quantityInput.value = quantity;
    }

    function increaseQuantity() {
        var quantityInput = document.getElementById("quantity");
        var quantity = parseInt(quantityInput.value);
        quantity++;
        quantityInput.value = quantity;
    }