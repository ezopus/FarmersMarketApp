let cardDetails = document.getElementById('cardDetails');
let bankDetails = document.getElementById('bankDetails');
let buttons = document.getElementById('payButtons');

document.getElementById('btnradio1').addEventListener('click', () => {
    cardDetails.classList.add('visually-hidden');
    bankDetails.classList.add('visually-hidden');
    buttons.classList.remove('visually-hidden');
})

document.getElementById('btnradio2').addEventListener('click', () => {
    cardDetails.classList.remove('visually-hidden');
    bankDetails.classList.add('visually-hidden');
    buttons.classList.remove('visually-hidden');
})

document.getElementById('btnradio3').addEventListener('click', () => {
    cardDetails.classList.add('visually-hidden');
    bankDetails.classList.remove('visually-hidden');
    buttons.classList.remove('visually-hidden');
})