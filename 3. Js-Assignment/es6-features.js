//1. Template Literals:
function greet(name, greeting) {
    return `${greeting}, ${name}!`;
}
console.log(greet("Karthik", "Good morning!"));

//2. Arrow functions
const square = num => num * num;

console.log(square(5));

//3. let and const to declare variables
const name1 = "Karthik";
let age = 24;

console.log(`Name: ${name1}, Age: ${age}`);

// Update age
age = 25;

console.log(`Updated Age: ${age}`);

//4. Destructuring assignment
const array = [1, 2, 3, 4, 5];
const [first, , , , last] = array;

console.log(`First element: ${first}, Last element: ${last}`);

//5. Default parameter
function location(city, country = "Unknown") {
    return `${city}, ${country}`;
}

console.log(location("Paris"));
console.log(location("Paris", "France"));

//6. Spread operator
const array1 = [1, 2, 3];
const array2 = [4, 5, 6];
const mergedArray = [...array1, ...array2];

console.log(mergedArray);

//7. Rest operator
function sum(...numbers) {
    return numbers.reduce((acc, num) => acc + num, 0);
}

console.log(sum(1, 2, 3, 4));

//8. Classes and Inheritance
class Vehicle {
    constructor(make, model) {
        this.make = make;
        this.model = model;
    }

    getDetails() {
        return `${this.make} ${this.model}`;
    }
}

class Car extends Vehicle {
    constructor(make, model) {
        super(make, model);
    }
}

const myCar = new Car("Benz", "Mercedes");
console.log(myCar.getDetails());

//9. Importing the function from module.js
import { CheckUser } from './module.js';

console.log(CheckUser("Karthik"));

//10. Enhanced Object Literals
const title = "Harry Potter";
const author = "J.K. Rowling";

const book = {
    title,
    author,
    getDetails() {
        return `${this.title} by ${this.author}`;
    }
};

console.log(book.getDetails());

//11. New Array Methods
const numbers = [1, 2, 3, 4];
const doubledNumbers = numbers.map(num => num * 2);

console.log(doubledNumbers);

const filteredNumbers = numbers.filter(num => num % 2 !== 0);

console.log(filteredNumbers);








