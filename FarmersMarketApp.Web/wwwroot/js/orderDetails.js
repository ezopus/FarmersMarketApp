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
			let statusCode = products[i]["status"];
			let status = '';
			switch (statusCode) {
				case 1: status = 'Open'
					break;
				case 2: status = 'In progress'
					break;
				case 3: status = 'Completed'
					break;
				case 4: status = 'Cancelled'
					break;
				default: status = 'Unknown'
			}
			productsHtml +=
			`
			<tr>
			<td colspan="2">${products[i]["name"]}</td>
			<td>${products[i]["amount"]}</td>
			<td>$${products[i]["priceAtPurchase"]}</td>
			<td>${status}</td >
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
