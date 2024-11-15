import { API_URL } from "/js/constants.js";

var dropDown = document.getElementById('farmDropDown');

dropDown.addEventListener('change', async () => {

    var farmerId = document.getElementById("farmerId").value;
    var response = await fetch(API_URL + "/farm/info/" + farmerId);
    var farms = await response.json();
    var farmId = dropDown.value;

    // Update the farm details
    document.getElementById('farmName').textContent = farms[farmId].name;
    document.getElementById('farmAddress').textContent = farms[farmId].address;
    document.getElementById('farmCity').textContent = farms[farmId].city;
    var img = document.getElementById('farmImage');
    img.src = farms[farmId].imageUrl;
    img.alt = farms[farmId].name;
});
