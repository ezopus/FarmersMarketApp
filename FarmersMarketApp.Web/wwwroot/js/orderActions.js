import { API_URL } from "/js/constants.js";

function completeOrder(farmerId, orderId) {
    fetch(API_URL + `/farmer/complete`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        },
        body: {
            'farmerId': farmerId,
            'orderId': orderId
        }
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                showToast("Order completed successfully!", 'success');
            } else {
                showToast("Could not complete order.", 'error');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            showToast('An unexpected error occurred.', 'error');
        });
}

function cancelOrder(farmerId, orderId) {
    fetch(API_URL + `/farmer/complete/${orderId}`, {
        method: 'GET',
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