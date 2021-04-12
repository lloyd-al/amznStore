export const addItemToCart = (cartItems, cartItemToAdd) => {
    const existingCartItem = cartItems.find(cartItem =>
        ((cartItem.product.id === cartItemToAdd.product.id) && (cartItem.size === cartItemToAdd.size))
    );

    if (existingCartItem) {
        return cartItems.map(cartItem =>
            ((cartItem.product.id === cartItemToAdd.product.id) && (cartItem.size === cartItemToAdd.size))
                ? { ...cartItem, quantity: cartItem.quantity + cartItemToAdd.quantity }
                : cartItem
        );
    }

    return [...cartItems, { ...cartItemToAdd }];
};

export const removeItemFromCart = (cartItems, cartItemToRemove) => {
    const existingCartItem = cartItems.find(
        cartItem => ((cartItem.product.id === cartItemToRemove.product.id) && (cartItem.size === cartItemToRemove.size))
    );

    if (existingCartItem.quantity === 1) {
        return cartItems.filter(cartItem =>
            ((cartItem.product.id !== cartItemToRemove.product.id) && (cartItem.size !== cartItemToRemove.size))
        );
    }

    return cartItems.map(cartItem =>
        ((cartItem.product.id === cartItemToRemove.product.id) && (cartItem.size === cartItemToRemove.size))
            ? { ...cartItem, quantity: cartItem.quantity - 1 }
            : cartItem
    );
};
