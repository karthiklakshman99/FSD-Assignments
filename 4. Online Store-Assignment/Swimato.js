// Sample food items data
const foodItems = [
  { id: 1, name: "Butter Chicken", cuisine: "indian", price: 350, description: "Rich creamy butter chicken.", image: "./Dishes/butter-chicken.jpg" },
  { id: 2, name: "Chow Mein", cuisine: "chinese", price: 200, description: "Stir-fried noodles with vegetables.", image: "./Dishes/chow-mein.jpg" },
  { id: 3, name: "Margherita Pizza", cuisine: "italian", price: 400, description: "Classic cheese pizza.", image: "./Dishes/margherita-pizza.jpg" },
  { id: 4, name: "Gulab Jamun", cuisine: "dessert", price: 100, description: "Delicious Indian dessert.", image: "./Dishes/gulab-jamun.jpg" },
];

const cart = [];
const foodList = document.getElementById("food-list");
const cartItems = document.getElementById("cart-items");
const totalPriceElement = document.getElementById("total-price");

function displayFoodItems(filteredFood = foodItems) {
  console.log("Displaying food items:", filteredFood);
  foodList.innerHTML = "";

  if (filteredFood.length === 0) {
    foodList.innerHTML = "<p class='text-center'>No dishes found. Try adjusting the filters or search term.</p>";
    return;
  }

  filteredFood.forEach((food) => {
    const foodCard = document.createElement("div");
    foodCard.classList.add("col-md-4");

    foodCard.innerHTML = `
      <div class="card mb-4">
        <img src="${food.image}" class="card-img-top" alt="${food.name}">
        <div class="card-body">
          <h5 class="card-title">${food.name}</h5>
          <p class="card-text">₹${food.price}</p>
          <button class="btn btn-danger add-to-cart" data-id="${food.id}">Add to Cart</button>
          <button class="btn btn-info view-details" data-id="${food.id}">Details</button>
        </div>
      </div>
    `;
    foodList.appendChild(foodCard);
  });

  attachEventListeners();
}

function attachEventListeners() {
  document.querySelectorAll(".add-to-cart").forEach((button) => {
    button.addEventListener("click", () => {
      const foodId = parseInt(button.getAttribute("data-id"));
      addToCart(foodId);
    });
  });

  document.querySelectorAll(".view-details").forEach((button) => {
    button.addEventListener("click", () => {
      const foodId = parseInt(button.getAttribute("data-id"));
      viewDetails(foodId);
    });
  });
}

function addToCart(foodId) {
  const food = foodItems.find((f) => f.id === foodId);
  const cartItem = cart.find((item) => item.id === foodId);

  if (cartItem) {
    cartItem.quantity += 1;
  } else {
    cart.push({ ...food, quantity: 1 });
  }

  updateCart();
}

function removeFromCart(foodId) {
  const cartIndex = cart.findIndex((item) => item.id === foodId);
  if (cartIndex !== -1) {
    cart.splice(cartIndex, 1);
    updateCart();
  }
}

// Function to update the cart display
function updateCart() {
  if (cart.length === 0) {
    cartItems.innerHTML = `<tr><td colspan="4" class="text-center">Your cart is empty.</td></tr>`;
    totalPriceElement.textContent = "0.00";
    return;
  }

  cartItems.innerHTML = "";
  let totalPrice = 0;

  cart.forEach((item) => {
    totalPrice += item.price * item.quantity;
    cartItems.innerHTML += `
      <tr>
        <td>${item.name}</td>
        <td>${item.quantity}</td>
        <td>₹${(item.price * item.quantity).toFixed(2)}</td>
        <td><button class="btn btn-danger btn-sm" onclick="removeFromCart(${item.id})">Remove</button></td>
      </tr>
    `;
  });

  totalPriceElement.textContent = totalPrice.toFixed(2);
}

// Function to filter food items
function filterFoodItems() {
  const searchText = document.getElementById("search-bar").value.toLowerCase();
  const cuisine = document.getElementById("cuisine-filter").value;
  const maxPrice = parseFloat(document.getElementById("price-filter").value);

  const filteredFood = foodItems.filter((food) => {
    const matchesSearch = food.name.toLowerCase().includes(searchText);
    const matchesCuisine = cuisine === "all" || food.cuisine === cuisine;
    const matchesPrice = isNaN(maxPrice) || food.price <= maxPrice;

    return matchesSearch && matchesCuisine && matchesPrice;
  });

  displayFoodItems(filteredFood);
}

// Function to view food details
function viewDetails(foodId) {
  const food = foodItems.find((f) => f.id === foodId);
  alert(`${food.name}\n\n${food.description}\n\nPrice: ₹${food.price}`);
}

// Event listeners for search and filters
document.getElementById("search-bar").addEventListener("input", filterFoodItems);
document.getElementById("cuisine-filter").addEventListener("change", filterFoodItems);
document.getElementById("price-filter").addEventListener("input", filterFoodItems);

// Initial display of food items
displayFoodItems();
