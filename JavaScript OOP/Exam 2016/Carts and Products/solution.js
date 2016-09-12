/* globals module */

"use strict";

function solve() {
    class Product {
        constructor(productType, name, price) {
            this._productType = productType;
            this._name = name;
            this._price = price;
        }

        get productType() {
            return this._productType;
        }

        get name() {
            return this._name;
        }

        get price() {
            return this._price;
        }
    }

    class ShoppingCart {
        constructor() {
            this._products = [];
        }

        get products() {
            return this._products;
        }

        add(product) {
            this._products.push(product);

            return this;
        }

        remove(product) {
            let index = this._products.indexOf(product);

            if (this._products.length < 1 || index < 0) {
                throw new Error();
            }

            this._products.splice(index, 1);
        }

        showCost() {
            if (this._products.length < 1) {
                return 0;
            }
            return this._products.reduce((a, b) => a + b.price, 0);
        }

        showProductTypes() {
            let result = [];

            if (this._products.length < 1) {
                return result;
            }


            this._products.forEach(function(product) {
                if (result.indexOf(product.productType) < 0) {
                    result.push(product.productType);
                }
            });
            return result.sort((a, b) => a.localeCompare(b));

        }

        getInfo() {
            if (this._products.length < 1) {
                return { totalPrice: 0, products: [] }
            }

            let uniqueProducts = []
            this._products.forEach(function(product) {
                let index = 0;
                uniqueProducts.forEach(function(uniqueProduct) {
                    if (uniqueProduct.name === product.name) {
                        uniqueProduct.quantity += 1;
                        uniqueProduct.totalPrice += product.price;
                    } else if (index === uniqueProducts.length - 1) {
                        uniqueProducts.push({ name: product.name, quantity: 1, totalPrice: product.price })
                    }
                }, index)
                if (uniqueProducts.length < 1) {
                    uniqueProducts.push({ name: product.name, quantity: 1, totalPrice: product.price })
                }
            });

            return { totalPrice: this.showCost, products: uniqueProducts }
        }
    }
    return {
        Product,
        ShoppingCart
    };
}

module.exports = solve;