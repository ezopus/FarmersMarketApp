import { API_URL } from "/js/constants.js";

const modalElement = document.getElementById('orderDetailsModal');
const modal = new bootstrap.Modal(modalElement);
const modalTitle = document.querySelector('.modal-title');
const modalBody = document.querySelector('.modal-body');
const orderDetailsBtns = document.querySelectorAll('button.orderBtn');

orderDetailsBtns.forEach(btn => {
    btn.addEventListener('click', async (e) => {
        e.preventDefault();

        const orderId = e.target.getAttribute('data-order-id');

        let res = await fetch(API_URL + "/order/details/" + orderId);
		let products = await res.json();

		let productsHtml = '';
		for (let i = 0; i < products.length; i++) {
			productsHtml +=
			`
			<tr>
			<td colspan="2">${products[i]["name"]}</td>
			<td>${products[i]["quantity"]}</td>
			<td>$${products[i]["price"]}</td>
			<td>${products[i]["status"]}</td>
			</tr>
			`
		}

        modalTitle.textContent = `Details for order ${orderId}`;

        modalBody.innerHTML = `
				<table class="w-100">
			<thead>
			<tr>
				<td colspan="2">Product</td>
				<td colspan="1">Quantity</td>
				<td colspan="1">Price</td>
				<td colspan="1">Status</td>
			</tr>
			</thead>
			<tbody>`
			+
			productsHtml
			+
			`</tbody>
		</table>
		`;

        modal.show();
    })
})
