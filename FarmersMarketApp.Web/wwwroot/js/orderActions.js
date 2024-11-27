import { API_URL } from "/js/constants.js";

function completeOrder(orderId) {
    fetch(API_URL + `/farmer/complete`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({'OrderId': orderId})
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data.success) {
                showToast(data.message, 'success');
            } else {
                showToast(data.message, 'error');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showToast(data.message, 'error');
        });
}

function cancelOrder(farmerId, orderId) {
    fetch(API_URL + `/farmer/complete/${orderId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                showToast("Order cancelled successfully!", 'success');
            } else {
                showToast("Could not cancel order.", 'error');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showToast('An unexpected error occurred.', 'error');
        });
}
function showToast(message, type) {
    var toastElement = document.getElementById('operationCompleteToast');
    var toastBody = toastElement.querySelector('.toast-body');
    toastBody.textContent = message;

    // Optional: Add success/error styling
    toastElement.classList.remove('bg-success', 'bg-danger'); // Clear previous styles
    if (type === 'success') {
        toastElement.classList.add('bg-success');
    } else if (type === 'error') {
        toastElement.classList.add('bg-danger');
    }

    var toast = new bootstrap.Toast(toastElement);
    toast.show();
}