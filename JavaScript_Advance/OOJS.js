
// Inheritance demo
//Parent class
class Vegetable {
    constructor(name, color) {
      this.name = name;
      this.color = color;
    }
  
    getDetails() {
      return `This vegetable is a ${this.name} and it is ${this.color}.`;
    }
  }
  
  //Child class
  class Carrot extends Vegetable {
    constructor() {
      super('Carrot', 'Orange');
    }
  
    cut() {
      console.log('Cutting the carrot...');
    }
  }
  
  //Child class
  class Potato extends Vegetable {
    constructor() {
      super('Potato', 'Brown');
    }
  
    peel() {
      console.log('Peeling the potato...');
    }
  }
  
  const carrot = new Carrot();
  console.log(carrot.getDetails()); 
  carrot.cut(); 
  
  const potato = new Potato();
  console.log(potato.getDetails()); 
  potato.peel(); 
  


  // Encapsulation demo
class Animal {
  constructor(name) {
    // Private variable
    this._name = name;
  }

  // Public method to get the name
  getName() {
    return this._name;
  }
}

// Polymorphism demo
class Dog extends Animal {
  constructor(name) {
    super(name);
  }

  // Override the base class method
  speak() {
    return `${this.getName()} says Woof!`;
  }
}

class Cat extends Animal {
  constructor(name) {
    super(name);
  }

  // Override the base class method
  speak() {
    return `${this.getName()} says Meow!`;
  }
}


const dog = new Dog("Dog");
const cat = new Cat("Cat");

console.log(dog.speak()); 
console.log(cat.speak()); 



  